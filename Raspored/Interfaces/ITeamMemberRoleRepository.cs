using Raspored.Models;
using System.Linq;

namespace Raspored.Interfaces
{
    public interface ITeamMemberRoleRepository
    {
        IQueryable<TeamMemberRole> GetAllTeamMemberRoles();
        TeamMemberRole GetTeamMemberRole(int teamMemberRoleId);
        void AddTeamMemberRole(TeamMemberRole teamMemberRole);
        void UpdateTeamMemberRole(TeamMemberRole teamMemberRole);
        void DeleteTeamMemberRole(TeamMemberRole teamMemberRole);
        bool IsConflictDetected(int teamMemberRoleId);
    }
}
