using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Raspored.Interfaces;
using Raspored.Models;
using Raspored.Models.DTOs;
using Raspored.Repositories;

namespace Raspored.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMemberController : ControllerBase
    {
        private readonly ITeamMemberRepository _teamMemberRepository;
        private readonly IMapper _mapper;


        public TeamMemberController(ITeamMemberRepository teamMemberRepository, IMapper mapper)
        {
            _teamMemberRepository = teamMemberRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/team-members")]
        public ActionResult GetMembers()
        {
            return Ok(_teamMemberRepository.GetAllTeamMembers().ProjectTo<TeamMemberDTO>(_mapper.ConfigurationProvider));
        }

        [HttpGet]
        [Route("/team-members/{id}")]
        public ActionResult GetTeamMember(int id)
        {
            var teamMember = _teamMemberRepository.GetTeamMember(id);
            if (teamMember == null)
            {
                return NotFound();
            }
            return Ok(teamMember);
        }

        [HttpPost]
        [Route("/api/team-members")]
        public IActionResult PostTeamMember([FromBody] TeamMember teamMember)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _teamMemberRepository.AddTeamMember(teamMember);

            return CreatedAtAction("GetTeamMember", new { id = teamMember.Id }, teamMember);
        }

        [HttpPut]
        [Route("/api/team-members/{id}")]
        public IActionResult PutTeamMember(int id, TeamMember teamMember)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teamMember.Id)
            {
                return BadRequest();
            }

            try
            {
                _teamMemberRepository.UpdateTeamMember(teamMember);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(teamMember);
        }

        [HttpDelete]
        [Route("/api/team-members/{id}")]
        public IActionResult DeleteTeamMember(int id)
        {
            var teamMember = _teamMemberRepository.GetTeamMemberById(id);
            if (teamMember == null)
            {
                return NotFound();
            }

            _teamMemberRepository.DeleteTeamMember(teamMember);
            return NoContent();
        }
    }
}
