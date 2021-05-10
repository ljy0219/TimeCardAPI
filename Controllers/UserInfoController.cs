using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeCard.IRepository;
using TimeCard.IService;
using TimeCard.Model;

namespace TimeCard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfoService _userInfoService;
        public UserInfoController(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }
        
        [HttpPost("")]
        public async Task<ActionResult> Login()
        {
            //UserInfo = await _userInfoService.FindAsync();
            var data = await _userInfoService.FindAsync(0);
            return Ok(data);
        }
    }
}