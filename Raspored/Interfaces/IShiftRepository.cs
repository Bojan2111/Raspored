using Raspored.Models;
using Raspored.Models.DTOs;
using System.Linq;

namespace Raspored.Interfaces
{
    public interface IShiftRepository
    {
        IQueryable<ShiftDTO> GetAllShifts();
        IQueryable GetShiftsByMonth(int month);
        ShiftDTO GetShift(int shiftId);
        Shift GetShiftById(int shiftId);
        void AddShift(Shift shift);
        void UpdateShift(Shift shift);
        void DeleteShift(Shift shift);
        bool IsConflictDetected(int shiftId);
    }
}
