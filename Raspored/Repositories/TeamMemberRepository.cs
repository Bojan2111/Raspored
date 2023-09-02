using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
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
    }
}
