using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeCard.IService;
using TimeCard.Model;

namespace TimeCard.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TimeCardsController : ControllerBase
    {
        private readonly ITimeCardInfoService _iTimeCardInfoService;
        public TimeCardsController(ITimeCardInfoService iTimeCardInfoService)
        {
            _iTimeCardInfoService = iTimeCardInfoService;
        }

        [HttpGet("TimeCards")]
        public async Task<ActionResult> GetTimeCards(int userid)
        {
            var TimeCards = await _iTimeCardInfoService.QueryAsync(x => x.UserID == userid);
            return Ok(TimeCards);
        }

        [HttpPost("TimeCards")]
        public async Task<ActionResult> AddTimeCards(int userid, TimeCards tm)
        {
            TimeCards tc = new TimeCards
            {
                UserID = userid,
                StartDate = tm.StartDate,
                EndDate = tm.EndDate,
                Mon = tm.Mon,
                Tues = tm.Tues,
                Wed = tm.Wed,
                Thur = tm.Thur,
                Fri = tm.Fri,
                Sat = tm.Sat,
                Sun = tm.Sun,
                Total = tm.Mon+tm.Tues+tm.Wed+tm.Thur+tm.Fri+tm.Sat+tm.Sun,
                CreatedDate = DateTime.Now
            };
            var b = await _iTimeCardInfoService.CreateAsync(tc);
            if (!b) return Content("Add TimeCard Failed");
            var TimeCards = await _iTimeCardInfoService.QueryAsync(x => x.UserID == userid);
         return Ok(TimeCards);
        }

        [HttpDelete("TimeCards")]
        public async Task<ActionResult> DeleteTimeCards(int id)
        {
            var tc = await _iTimeCardInfoService.FindAsync(id);
            if (tc == null) return Content("TimeCard Not Found");
            var b = await _iTimeCardInfoService.DeleteAsync(id);
            if (!b) return Content("Delete TimeCard Failed");
            return Ok("Delete TimeCard Successfully");
        }
    }
}