using Raspored.Models;
using Raspored.Models.DTOs;
using System.Linq;

namespace Raspored.Interfaces
{
    public interface ITeamMemberRepository
    {
        IQueryable<TeamMember> GetAllTeamMembers();
        TeamMemberDTO GetTeamMember(int teamMemberId);
        void AddTeamMember(TeamMemberDTO teamMember);
        void UpdateTeamMember(TeamMemberDTO teamMember);
        void DeleteTeamMember(TeamMemberDTO teamMember);
    }
}
