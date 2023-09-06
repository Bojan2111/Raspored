using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Raspored.Interfaces;
using Raspored.Models.DTOs;
using Raspored.Repositories;

namespace Raspored.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalScheduleController : ControllerBase
    {
        private readonly IPersonalScheduleRepository _scheduleRepository;

        public PersonalScheduleController(IPersonalScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        [AllowAnonymous]
        [HttpGet("/personal-schedule/{teamMemberId}")]
        public IActionResult GetPersonalSchedule(int teamMemberId)
        {
            PersonalSchedule personalSchedule = _scheduleRepository.GetPersonalSchedule(teamMemberId);
            return Ok(personalSchedule);
        }
    }
}
