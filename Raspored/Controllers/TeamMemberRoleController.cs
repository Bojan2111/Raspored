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
    public class TeamMemberRoleController : ControllerBase
    {
        private readonly ITeamMemberRoleRepository _teamMemberRoleRepository;


        public TeamMemberRoleController(ITeamMemberRoleRepository teamMemberRoleRepository)
        {
            _teamMemberRoleRepository = teamMemberRoleRepository;
        }

        [Authorize]
        [HttpGet]
        [Route("/team-member-roles")]
        public IActionResult GetTeamMemberRoles()
        {
            return Ok(_teamMemberRoleRepository.GetAllTeamMemberRoles());
        }

        [Authorize]
        [HttpGet]
        [Route("/team-member-roles/{id}")]
        public IActionResult GetTeamMemberRole(int id)
        {
            var teamMemberRole = _teamMemberRoleRepository.GetTeamMemberRole(id);
            if (teamMemberRole == null)
            {
                return NotFound();
            }
            return Ok(teamMemberRole);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("/team-member-roles")]
        public IActionResult PostTeamMemberRole([FromBody] TeamMemberRole teamMemberRole)
        {
            try
            {
                if (_teamMemberRoleRepository.IsConflictDetected(teamMemberRole.Id))
                {
                    throw new DataConflictException("A team member role with the same ID already exists.");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _teamMemberRoleRepository.AddTeamMemberRole(teamMemberRole);

                return CreatedAtAction("GetTeamMemberRole", new { id = teamMemberRole.Id }, teamMemberRole);
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
        [Route("/team-member-roles/{id}")]
        public IActionResult PutTeamMemberRole(int id, TeamMemberRole teamMemberRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teamMemberRole.Id)
            {
                return BadRequest();
            }

            try
            {
                _teamMemberRoleRepository.UpdateTeamMemberRole(teamMemberRole);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(teamMemberRole);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete]
        [Route("/team-member-roles/{id}")]
        public IActionResult DeleteTeamMemberRole(int id)
        {
            var teamMemberRole = _teamMemberRoleRepository.GetTeamMemberRole(id);
            if (teamMemberRole == null)
            {
                return NotFound();
            }

            _teamMemberRoleRepository.DeleteTeamMemberRole(teamMemberRole);
            return NoContent();
        }
    }
}
