using AutoMapper;
using AutoMapper.QueryableExtensions;
using Raspored.Interfaces;
using Raspored.Models;
using Raspored.Models.DTOs;
using System.Linq;

namespace Raspored.Repositories
{
    public class TeamMemberRepository : ITeamMemberRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TeamMemberRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddTeamMember(TeamMemberDTO teamMember)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteTeamMember(TeamMemberDTO teamMember)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<TeamMemberDTO> GetAllTeamMembers()
        {
            throw new System.NotImplementedException();
            //return _context.TeamMembers;
        }

        public TeamMemberDTO GetTeamMember(int teamMemberId)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateTeamMember(TeamMemberDTO teamMember)
        {
            throw new System.NotImplementedException();
        }
    }
}
