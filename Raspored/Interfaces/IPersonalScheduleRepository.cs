using Raspored.Models.DTOs;
using System.Linq;

namespace Raspored.Interfaces
{
    public interface IPersonalScheduleRepository
    {
        IQueryable<PersonalSchedule> GetAll();
        PersonalSchedule GetById(int teamMemberId);
        void Add(PersonalSchedule personalSchedule);
        void Update(PersonalSchedule personalSchedule);
        void Delete(PersonalSchedule personalSchedule);
    }
}
