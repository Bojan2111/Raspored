using AutoMapper;
using Raspored.Models.DTOs;
using Raspored.Models.Login;
using Raspored.Models;
using System.Collections.Generic;
using Raspored.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Raspored.Repositories
{
    public class PersonalScheduleRepository : IPersonalScheduleRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PersonalScheduleRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddPersonalSchedule(PersonalSchedule personalSchedule)
        {
            throw new System.NotImplementedException();
        }

        public void DeletePersonalSchedule(PersonalSchedule personalSchedule)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<PersonalSchedule> GetAllPersonalSchedules()
        {
            throw new System.NotImplementedException();
        }

        public PersonalSchedule GetPersonalSchedule(int teamMemberId)
        {
            TeamMember teamMember = _context.TeamMembers.FirstOrDefault(x => x.Id == teamMemberId);
            Team team = _context.Teams.FirstOrDefault(x => x.Id == teamMember.TeamId);
            ApplicationUser user = _context.Users.FirstOrDefault(x => x.Id == teamMember.UserId);
            TeamMemberRole teamMemberRole = _context.TeamMemberRoles.FirstOrDefault(x => x.Id == teamMember.TeamMemberRoleId);
            List<Shift> shifts = _context.Shifts.Include(s => s.ShiftType).Where(x => x.TeamMemberId == teamMemberId)
                
                .ToList();
            string monthName = shifts[0].Date.ToString("MMMM").ToUpper();

            PersonalSchedule personalSchedule = _mapper.Map<TeamMember, PersonalSchedule>(teamMember);
            _mapper.Map(team, personalSchedule);
            _mapper.Map(user, personalSchedule);
            _mapper.Map(teamMemberRole, personalSchedule);
            personalSchedule.MonthName = monthName;
            personalSchedule.Shifts = _mapper.Map<List<ShiftDTO>>(shifts);

            return personalSchedule;
        }

        public void UpdatePersonalSchedule(PersonalSchedule projekcija)
        {
            throw new System.NotImplementedException();
        }
    }
}
