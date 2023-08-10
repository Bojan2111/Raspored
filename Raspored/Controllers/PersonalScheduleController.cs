using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Raspored.Models.DTOs;
using Raspored.Repositories;

namespace Raspored.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalScheduleController : ControllerBase
    {
        private readonly PersonalScheduleRepository _scheduleRepository;

        public PersonalScheduleController(PersonalScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        [HttpGet("api/personal-schedule/{teamMemberId}")]
        public IActionResult GetPersonalSchedule(int teamMemberId)
        {
            PersonalSchedule personalSchedule = _scheduleRepository.GetById(teamMemberId);
            return Ok(personalSchedule);
        }
    }
}
