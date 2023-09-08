﻿using Microsoft.EntityFrameworkCore;
using Raspored.CustomExceptions;
using Raspored.Interfaces;
using Raspored.Models;
using System.Linq;

namespace Raspored.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly AppDbContext _context;

        public PositionRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddPosition(Position position)
        {
            if (IsConflictDetected(position.Id))
            {
                throw new DataConflictException("A position with the same ID already exists.");
            }
            _context.Positions.Add(position);
            _context.SaveChanges();
        }

        public void DeletePosition(Position position)
        {
            _context.Positions.Remove(position);
            _context.SaveChanges();
        }

        public IQueryable<Position> GetAllPositions()
        {
            return _context.Positions;
        }

        public Position GetPosition(int positionId)
        {
            return _context.Positions.FirstOrDefault(x => x.Id == positionId);
        }

        public void UpdatePosition(Position position)
        {
            _context.Entry(position).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public bool IsConflictDetected(int positionId)
        {
            return _context.Positions.Any(ct => ct.Id == positionId);
        }
    }
}
