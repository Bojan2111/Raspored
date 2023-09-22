using Raspored.Models.DTOs;
using System.Linq;

namespace Raspored.Interfaces
{
    public interface IPersonalScheduleRepository
    {
        IQueryable<PersonalSchedule> GetAllPersonalSchedules();
        PersonalSchedule GetPersonalSchedule(int teamMemberId, int month);
        void AddPersonalSchedule(PersonalSchedule personalSchedule);
        void UpdatePersonalSchedule(PersonalSchedule personalSchedule);
        void DeletePersonalSchedule(PersonalSchedule personalSchedule);
    }
}
