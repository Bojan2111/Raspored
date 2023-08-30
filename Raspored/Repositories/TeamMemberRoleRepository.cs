using Raspored.Interfaces;
using Raspored.Models;
using System.Linq;

namespace Raspored.Repositories
{
    public class TeamMemberRoleRepository : ITeamMemberRoleRepository
    {
        private readonly AppDbContext _context;

        public TeamMemberRoleRepository(AppDbContext context)
        {
            _context = context;
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
