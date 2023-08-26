using AutoMapper;
using Raspored.Interfaces;
using Raspored.Models;
using Raspored.Models.DTOs;
using System.Linq;

namespace Raspored.Repositories
{
    public class TeamMemberRoleRepository : ITeamMemberRoleRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TeamMemberRoleRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void AddTeamMemberRole(TeamMemberRole teamMemberRole)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteTeamMemberRole(TeamMemberRole teamMemberRole)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<TeamMemberRole> GetAllTeamMemberRoles()
        {
            return _context.TeamMemberRoles.AsQueryable();
        }

        public TeamMemberRole GetTeamMemberRole(int teamMemberRoleId)
        {
            return _context.TeamMemberRoles.FirstOrDefault(x => x.Id == teamMemberRoleId);
        }

        public void UpdateTeamMemberRole(TeamMemberRole teamMemberRole)
        {
            throw new System.NotImplementedException();
        }
    }
}
