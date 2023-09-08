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
    public class TeamMemberRepository : ITeamMemberRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TeamMemberRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddTeamMember(TeamMember teamMember)
        {
            if (IsConflictDetected(teamMember.Id))
            {
                throw new DataConflictException("A team member with the same ID already exists.");
            }
            _context.TeamMembers.Add(teamMember);
            _context.SaveChanges();
        }

        public void DeleteTeamMember(TeamMember teamMember)
        {
            _context.TeamMembers.Remove(teamMember);
            _context.SaveChanges();
        }

        public IQueryable<TeamMember> GetAllTeamMembers()
        {
            return _context.TeamMembers.AsQueryable();
        }

        public TeamMemberDTO GetTeamMember(int teamMemberId)
        {
            var teamMemberDto = _context.TeamMembers
                .Where(x => x.Id == teamMemberId)
                .ProjectTo<TeamMemberDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefault();

            return teamMemberDto;
        }

        public TeamMember GetTeamMemberById(int teamMemberId)
        {
            return _context.TeamMembers.FirstOrDefault(x => x.Id == teamMemberId);
        }

        public void UpdateTeamMember(TeamMember teamMember)
        {
            _context.Entry(teamMember).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
        public bool IsConflictDetected(int teamMemberId)
        {
            return _context.TeamMembers.Any(ct => ct.Id == teamMemberId);
        }
    }
}
