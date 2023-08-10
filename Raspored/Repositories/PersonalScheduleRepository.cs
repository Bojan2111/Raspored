using AutoMapper;
using Raspored.Models.DTOs;
using Raspored.Models.Login;
using Raspored.Models;
using System.Collections.Generic;
using Raspored.Interfaces;
using System.Linq;

namespace Raspored.Repositories
{
    public class PersonalScheduleRepository : IPersonalScheduleRepository
    {
        private readonly IMapper _mapper;

        public PersonalScheduleRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void Add(PersonalSchedule personalSchedule)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(PersonalSchedule personalSchedule)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<PersonalSchedule> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public PersonalSchedule GetById(int teamMemberId)
        {
            // Fetch data from the database and map to PersonalSchedule
            Team team = new Team();// Get team from the database based on teamMemberId
            TeamMember teamMember = new TeamMember();// Get team member from the database based on teamMemberId
            ApplicationUser user = new ApplicationUser();// Get user from the database based on teamMember.UserId
            List<Shift> shifts = new List<Shift>();// Get shifts from the database based on teamMemberId

            PersonalSchedule personalSchedule = _mapper.Map<Team, PersonalSchedule>(team);
            _mapper.Map(teamMember, personalSchedule);
            _mapper.Map(user, personalSchedule);
            personalSchedule.Shifts = _mapper.Map<List<ShiftDTO>>(shifts);

            return personalSchedule;
        }

        public void Update(PersonalSchedule projekcija)
        {
            throw new System.NotImplementedException();
        }
    }
}
