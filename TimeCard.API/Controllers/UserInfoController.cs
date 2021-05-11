using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeCard.IService;
using TimeCard.Model;
using TimeCard.API.Utilities;

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
        public async Task<ActionResult> Login(string username,string pwd)
        {
            //UserInfo = await _userInfoService.FindAsync();
            var data = await _userInfoService.FindAsync(x=>x.UserName == username && x.UserPWD == MD5.MD5Encrypt32(pwd));
            if (data == null) return Content("Login Failed");
            return Ok("Login Successfully");
        }

        [HttpPost("SignUp")]
        public async Task<ActionResult> Create(string username, string pwd,string email,string usertype)
        {
            var user = await _userInfoService.FindAsync(x=> x.UserName == username);
            if (user != null) return Content("Error, UserName has already existed");

            UserInfo ui = new UserInfo
            {
                UserName = username,
                UserPWD = MD5.MD5Encrypt32(pwd),
                Email = email,
                UserType = usertype,
                CreatedDate = DateTime.Now
            };
            
            var b = await _userInfoService.CreateAsync(ui);
            if (!b) return Content("Create user Failed");
            return Ok("Create user Successfully");
        }

        [HttpDelete("UserInfo")]
        public async Task<ActionResult> DeleteUser(int userid)
        {
            var user = await _userInfoService.FindAsync(x => x.ID == userid);
            if (user == null) return Content("Failed, User not found");
            var b = await _userInfoService.DeleteAsync(userid);
            if (!b) return Content("Delete user Failed");
            return Ok("Delete user Successfully");
        }

        [HttpGet("User")]
        public async Task<ActionResult> GetUserInfo(int userid)
        {
            var user = await _userInfoService.FindAsync(userid);
            if (user == null) return Content("User not found");
            return Ok(user);
        }

        [HttpGet("UserList")]
        public async Task<ActionResult> GetUserList()
        {
            List<UserInfo> ul = await _userInfoService.QueryAsync();
            if (ul != null && ul.Count > 0) return Ok(ul);
            return Content("No users");
        }
        

    }
}