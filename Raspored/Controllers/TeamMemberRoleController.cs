using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Raspored.Interfaces;
using Raspored.Models;
using Raspored.Repositories;

namespace Raspored.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMemberRoleController : ControllerBase
    {
        private readonly ITeamMemberRoleRepository _teamMemberRoleRepository;
        private readonly IMapper _mapper;


        public TeamMemberRoleController(ITeamMemberRoleRepository teamMemberRoleRepository, IMapper mapper)
        {
            _teamMemberRoleRepository = teamMemberRoleRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/api/team-member-roles")]
        public IActionResult GetTeamMemberRoles()
        {
            return Ok(_teamMemberRoleRepository.GetAllTeamMemberRoles());
        }

        [HttpGet]
        [Route("/api/team-member-roles/{id}")]
        public IActionResult GetTeamMemberRole(int id)
        {
            var teamMemberRole = _teamMemberRoleRepository.GetTeamMemberRole(id);
            if (teamMemberRole == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost]
        [Route("/api/team-member-roles")]
        public IActionResult PostTeamMemberRole([FromBody] TeamMemberRole teamMemberRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _teamMemberRoleRepository.AddTeamMemberRole(teamMemberRole);

            return CreatedAtAction("GetTeamMemberRole", new { id = teamMemberRole.Id }, teamMemberRole);
        }

        [HttpPut]
        [Route("/api/team-member-roles/{id}")]
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

        [HttpDelete]
        [Route("/api/team-member-roles/{id}")]
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
