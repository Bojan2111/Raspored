using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Raspored.Interfaces;
using Raspored.Models.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Raspored.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;


        public TeamsController(ITeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/api/teams")]
        public IActionResult GetTeams()
        {
            var teams = _teamRepository.GetAllTeams();
            return Ok(teams);
        }

        [HttpGet]
        [Route("/api/teams/{id}")]
        public IActionResult GetTeam(int id)
        {
            var team = _teamRepository.GetTeam(id);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }
    }
}
