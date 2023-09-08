using Raspored.Models;
using System.Linq;

namespace Raspored.Interfaces
{
    public interface IPositionRepository
    {
        IQueryable<Position> GetAllPositions();
        Position GetPosition(int positionId);
        void AddPosition(Position position);
        void UpdatePosition(Position position);
        void DeletePosition(Position position);
        bool IsConflictDetected(int positionId);
    }
}
