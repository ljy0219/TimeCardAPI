using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeCard.IRepository;
using TimeCard.IService;
using TimeCard.Model;
using TimeCard.Repository;

namespace TimeCard.API.Controllers
{
    public class LogsController : ControllerBase
    {
        private readonly ILogService _iLogService;
        public LogsController(ILogService iLogService)
        {
            _iLogService = iLogService;
        }

        public async Task<bool> AddLog(int userid, string desc)
        {

            Logs log = new Logs
            {
                UserID = userid,
                Description = desc,
                CreatedDate = DateTime.Now
            };
            var b = await _iLogService.CreateAsync(log);
            return b;
        }
    }
}