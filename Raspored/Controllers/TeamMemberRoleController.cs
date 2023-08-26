using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Raspored.Interfaces;

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
    }
}
