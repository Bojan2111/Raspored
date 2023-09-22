using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Raspored.Interfaces;

namespace Raspored.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalScheduleController : ControllerBase
    {
        private readonly IPersonalScheduleRepository _scheduleRepository;

        public PersonalScheduleController(IPersonalScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        [HttpGet("/personal-schedule/{teamMemberId}")]
        public IActionResult GetPersonalSchedule(int teamMemberId, int month)
        {
            var personalSchedule = _scheduleRepository.GetPersonalSchedule(teamMemberId, month);
            if (personalSchedule == null)
            {
                return NotFound();
            }
            return Ok(personalSchedule);
        }
    }
}
