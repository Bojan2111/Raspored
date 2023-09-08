using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Raspored.CustomExceptions;
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
        public void AddShift(Shift shift)
        {
            if (IsConflictDetected(shift.Id))
            {
                throw new DataConflictException("A shift with the same ID already exists.");
            }
            _context.Shifts.Add(shift);
            _context.SaveChanges();
        }

        public void DeleteShift(Shift shift)
        {
            _context.Shifts.Remove(shift);
            _context.SaveChanges();
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

        public Shift GetShiftById(int id)
        {
            return _context.Shifts.FirstOrDefault(shift => shift.Id == id);
        }

        public void UpdateShift(Shift shift)
        {
            _context.Entry(shift).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public bool IsConflictDetected(int shiftId)
        {
            return _context.Shifts.Any(ct => ct.Id == shiftId);
        }
    }
}
