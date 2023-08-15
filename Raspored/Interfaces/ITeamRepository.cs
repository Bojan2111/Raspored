using Raspored.Models.DTOs;
using System.Linq;

namespace Raspored.Interfaces
{
    public interface ITeamRepository
    {
        IQueryable<TeamDTO> GetAllTeams();
        TeamDTO GetTeam(int teamMemberId);
        void AddTeam(TeamDTO team);
        void UpdateTeam(TeamDTO team);
        void DeleteTeam(TeamDTO team);
    }
}
