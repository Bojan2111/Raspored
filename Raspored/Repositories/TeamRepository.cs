using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Raspored.Interfaces;
using Raspored.Models;
using Raspored.Models.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;

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

        public TeamDTO GetTeam(int teamId)
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

        public void UpdateTeam(TeamDTO team)
        {
            throw new System.NotImplementedException();
        }
    }
}
