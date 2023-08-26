using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Raspored.Interfaces;
using Raspored.Models.DTOs;

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
    }
}
