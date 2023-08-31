using Microsoft.EntityFrameworkCore;
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
            _context.TeamMemberRoles.Add(teamMemberRole);
            _context.SaveChanges();
        }

        public void DeleteTeamMemberRole(TeamMemberRole teamMemberRole)
        {
            _context.TeamMemberRoles.Remove(teamMemberRole);
            _context.SaveChanges();
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
            _context.Entry(teamMemberRole).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
