using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SqlSugar.IOC;
using TimeCard.IRepository;
using TimeCard.IService;
using TimeCard.Repository;
using TimeCard.Serivce;
using TimeCard.API.Utilities._AutoMapper;

namespace TimeCard.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "TimeCard.API", Version = "v1"});
            });

            #region SqlSugarIOC
            services.AddSqlSugar(new IocConfig()
            {
                ConnectionString = this.Configuration["SqlConn"],
                DbType =IocDbType.MySql,
                IsAutoCloseConnection = true
            });

            #endregion
            
            services.AddScoped<IUserInfoRepository,UserInfoRepository>();
            services.AddScoped<ITimeCardInfoRepository, TimeCardInfoRepository>();
            services.AddScoped<ILogRepository, LogsRepository>();
            services.AddScoped<IUserInfoService, UserInfoService>();
            services.AddScoped<ITimeCardInfoService, TimeCardInfoService>();
            services.AddScoped<ILogService,LogService>();

            services.AddAutoMapper(typeof(CustomAutoMapperProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TimeCard.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            //app.UseAuthentication();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
    
}