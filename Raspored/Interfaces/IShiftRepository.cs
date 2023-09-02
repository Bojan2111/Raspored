using Raspored.Models;
using Raspored.Models.DTOs;
using System.Linq;

namespace Raspored.Interfaces
{
    public interface IShiftRepository
    {
        IQueryable<ShiftDTO> GetAllShifts();
        ShiftDTO GetShift(int teamMemberId);
        void AddShift(Shift shift);
        void UpdateShift(Shift shift);
        void DeleteShift(Shift shift);
    }
}
