using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Raspored.Interfaces;
using Raspored.Models;
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

        [HttpGet]
        [Route("/api/teams-with-members")]
        public IActionResult GetTeamsWithMembers()
        {
            return Ok(_teamRepository.GetTeamsWithMembers());
        }

        [HttpGet]
        [Route("/api/teams-with-members/{id}")]
        public IActionResult GetTeamWithMembers(int id)
        {
            var team = _teamRepository.GetTeamWithMembers(id);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }

        [HttpPost]
        [Route("/api/teams")]
        public IActionResult PostTeam([FromBody] Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _teamRepository.AddTeam(team);

            return CreatedAtAction("GetTeam", new { id = team.Id }, team);
        }

        [HttpPut]
        [Route("/api/teams/{id}")]
        public IActionResult PutTeam(int id, Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != team.Id)
            {
                return BadRequest();
            }

            try
            {
                _teamRepository.UpdateTeam(team);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(team);
        }

        [HttpDelete]
        [Route("/api/teams/{id}")]
        public IActionResult DeletePaket(int id)
        {
            var team = _teamRepository.GetTeam(id);
            if (team == null)
            {
                return NotFound();
            }

            _teamRepository.DeleteTeam(team);
            return NoContent();
        }
    }
}
