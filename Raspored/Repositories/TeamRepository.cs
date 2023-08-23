using AutoMapper;
using Raspored.Interfaces;
using Raspored.Models;
using Raspored.Models.DTOs;
using System.Linq;

namespace Raspored.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TeamRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void AddTeam(TeamDTO team)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteTeam(TeamDTO team)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<TeamDTO> GetAllTeams()
        {
            throw new System.NotImplementedException();
        }

        public TeamDTO GetTeam(int teamMemberId)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateTeam(TeamDTO team)
        {
            throw new System.NotImplementedException();
        }
    }
}
