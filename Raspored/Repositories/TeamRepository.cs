using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Raspored.CustomExceptions;
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
        public void AddTeam(Team team)
        {
            if (IsConflictDetected(team.Id))
            {
                throw new DataConflictException("A team with the same ID already exists.");
            }
            _context.Teams.Add(team);
            _context.SaveChanges();
        }

        public void DeleteTeam(Team team)
        {
            _context.Teams.Remove(team);
            _context.SaveChanges();
        }
        public IQueryable<Team> GetAllTeams()
        {
            return _context.Teams.AsQueryable();
        }

        public IQueryable<TeamDTO> GetTeamsWithMembers()
        {
            var teams = _context.Teams
                .Select(team => new TeamDTO
                {
                    Id = team.Id,
                    Name = team.Name,
                    TeamMembers = _context.TeamMembers
                        .Where(member => member.TeamId == team.Id)
                        .Select(member => new TeamMemberDTO
                        {
                            Id = member.Id,
                            Name = $"{member.User.LastName} {member.User.FirstName}",
                            TeamName = member.Team.Name,
                            Role = member.TeamMemberRole.Name
                        })
                        .ToList()
                })
                .AsQueryable();

            return teams;
        }

        public Team GetTeam(int teamId)
        {
            return _context.Teams.FirstOrDefault(t => t.Id == teamId);
        }

        public TeamDTO GetTeamWithMembers(int teamId)
        {
            var team = _context.Teams.FirstOrDefault(t => t.Id == teamId);

            if (team == null)
            {
                return null;
            }

            var teamDto = _mapper.Map<TeamDTO>(team);
            teamDto.TeamMembers = _context.TeamMembers
                .Where(member => member.TeamId == teamId)
                .ProjectTo<TeamMemberDTO>(_mapper.ConfigurationProvider)
                .ToList();

            return teamDto;
        }

        public void UpdateTeam(Team team)
        {
            _context.Entry(team).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

        }
        public bool IsConflictDetected(int teamId)
        {
            return _context.Teams.Any(ct => ct.Id == teamId);
        }
    }
}
