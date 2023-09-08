using Raspored.Models;
using Raspored.Models.DTOs;
using System.Linq;

namespace Raspored.Interfaces
{
    public interface ITeamMemberRepository
    {
        IQueryable<TeamMember> GetAllTeamMembers();
        TeamMemberDTO GetTeamMember(int teamMemberId);
        TeamMember GetTeamMemberById(int teamMemberId);
        void AddTeamMember(TeamMember teamMember);
        void UpdateTeamMember(TeamMember teamMember);
        void DeleteTeamMember(TeamMember teamMember);
        bool IsConflictDetected(int teamMemberId);
    }
}
