using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Raspored.CustomExceptions;
using Raspored.Interfaces;
using Raspored.Models;
using System;

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

        [Authorize]
        [HttpGet]
        [Route("/teams")]
        public IActionResult GetTeams()
        {
            var teams = _teamRepository.GetAllTeams();
            return Ok(teams);
        }

        [Authorize]
        [HttpGet]
        [Route("/teams/{id}")]
        public IActionResult GetTeam(int id)
        {
            var team = _teamRepository.GetTeam(id);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }

        [Authorize]
        [HttpGet]
        [Route("/teams-with-members")]
        public IActionResult GetTeamsWithMembers()
        {
            return Ok(_teamRepository.GetTeamsWithMembers());
        }

        [Authorize]
        [HttpGet]
        [Route("/teams-with-members/{id}")]
        public IActionResult GetTeamWithMembers(int id)
        {
            var team = _teamRepository.GetTeamWithMembers(id);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("/teams")]
        public IActionResult PostTeam([FromBody] Team team)
        {
            try
            {
                if (_teamRepository.IsConflictDetected(team.Id))
                {
                    throw new DataConflictException("A team with the same ID already exists.");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _teamRepository.AddTeam(team);

                return CreatedAtAction("GetTeam", new { id = team.Id }, team);
            }
            catch (DataConflictException ex)
            {
                return Conflict(new { ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request." });
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPut]
        [Route("/teams/{id}")]
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

        [Authorize(Roles = "admin")]
        [HttpDelete]
        [Route("/teams/{id}")]
        public IActionResult DeleteTeam(int id)
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
