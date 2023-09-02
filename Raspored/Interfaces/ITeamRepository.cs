using Raspored.Models;
using Raspored.Models.DTOs;
using System.Linq;

namespace Raspored.Interfaces
{
    public interface ITeamRepository
    {
        IQueryable<Team> GetAllTeams();
        IQueryable<TeamDTO> GetTeamsWithMembers();
        Team GetTeam(int teamId);
        TeamDTO GetTeamWithMembers(int teamId);
        void AddTeam(Team team);
        void UpdateTeam(Team team);
        void DeleteTeam(Team team);
    }
}
