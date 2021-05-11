using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimeCard.IService;
using TimeCard.Model;
using TimeCard.API.Utilities;
using TimeCard.API.Utilities.ApiResult;
using TimeCard.Model.DTO;

namespace TimeCard.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfoService _userInfoService;
        public UserInfoController(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }
        
        [HttpGet("Login")]
        public async Task<ApiResult> Login([FromServices] IMapper iMapper,string username,string pwd)
        {
            //UserInfo = await _userInfoService.FindAsync();
            var user = await _userInfoService.FindAsync(x=>x.UserName == username && x.UserPWD == MD5.MD5Encrypt32(pwd));
            if (user == null) return ApiResultHelper.Error("Login Falied");
            UserInfoDTO userDTO = iMapper.Map<UserInfoDTO>(user);
            return ApiResultHelper.Success(userDTO,"Login Successfully");
        }

        [HttpPost("SignUp")]
        public async Task<ApiResult> Create(string username, string pwd,string email,string usertype)
        {
            var user = await _userInfoService.FindAsync(x=> x.UserName == username);
            if (user != null) return ApiResultHelper.Error("Error, UserName has already existed");

            UserInfo ui = new UserInfo
            {
                UserName = username,
                UserPWD = MD5.MD5Encrypt32(pwd),
                Email = email,
                UserType = usertype,
                CreatedDate = DateTime.Now
            };
            
            var b = await _userInfoService.CreateAsync(ui);
            if (!b) return ApiResultHelper.Error("Create user Failed");
            return ApiResultHelper.Success(null,"Create user Successfully");
        }

        [HttpDelete("UserInfo")]
        public async Task<ApiResult> DeleteUser(int userid)
        {
            var user = await _userInfoService.FindAsync(x => x.ID == userid);
            if (user == null) return ApiResultHelper.Error("Failed, User not found");
            var b = await _userInfoService.DeleteAsync(userid);
            if (!b) return ApiResultHelper.Error("Delete user Failed");
            return ApiResultHelper.Success(null,"Delete user Successfully");
        }

        [HttpGet("User")]
        public async Task<ApiResult> GetUserInfo([FromServices] IMapper iMapper,int userid)
        {
            var user = await _userInfoService.FindAsync(userid);
            if (user == null) return ApiResultHelper.Error("User not found");
            var userDTO = iMapper.Map<UserInfoDTO>(user);
            return ApiResultHelper.Success(userDTO,"Success");
        }

        [HttpGet("UserList")]
        public async Task<ApiResult> GetUserList([FromServices] IMapper iMapper)
        {
            List<UserInfo> ul = await _userInfoService.QueryAsync();
            if (ul != null && ul.Count > 0)
            {
                List<UserInfoDTO> ulDTO = new List<UserInfoDTO>();
                foreach (UserInfo user in ul)
                {
                    ulDTO.Add(iMapper.Map<UserInfoDTO>(user));
                }
                return ApiResultHelper.Success(ulDTO,"Success");
            }
            return ApiResultHelper.Error("No users");
        }
        

    }
}