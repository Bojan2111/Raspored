using Raspored.Models.DTOs;
using System.Linq;

namespace Raspored.Interfaces
{
    public interface ITeamMemberRepository
    {
        IQueryable<TeamMemberDTO> GetAllTeamMembers();
        TeamMemberDTO GetTeamMember(int teamMemberId);
        void AddTeamMember(TeamMemberDTO teamMember);
        void UpdateTeamMember(TeamMemberDTO teamMember);
        void DeleteTeamMember(TeamMemberDTO teamMember);
    }
}
