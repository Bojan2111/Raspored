using Microsoft.EntityFrameworkCore;
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
            throw new System.NotImplementedException();
        }

        public void DeletePosition(Position position)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Position> GetAllPositions()
        {
            throw new System.NotImplementedException();
        }

        public Position GetPosition(int positionId)
        {
            throw new System.NotImplementedException();
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
    }
}
