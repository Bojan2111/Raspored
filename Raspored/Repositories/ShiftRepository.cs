using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Raspored.Interfaces;
using Raspored.Models;
using Raspored.Models.DTOs;
using System.Linq;

namespace Raspored.Repositories
{
    public class ShiftRepository : IShiftRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ShiftRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void AddShift(ShiftDTO shift)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteShift(ShiftDTO shift)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<ShiftDTO> GetAllShifts()
        {
            return _context.Shifts.AsQueryable().ProjectTo<ShiftDTO>(_mapper.ConfigurationProvider);
        }

        public ShiftDTO GetShift(int id)
        {
            return _context.Shifts
                .Where(shift => shift.Id == id)
                .ProjectTo<ShiftDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
        }

        public void UpdateShift(ShiftDTO shift)
        {
            throw new System.NotImplementedException();
        }
    }
}
