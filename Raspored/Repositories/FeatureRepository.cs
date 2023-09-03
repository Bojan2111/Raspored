using Raspored.Interfaces;
using Raspored.Models;
using System.Collections.Generic;
using System.Linq;

namespace Raspored.Repositories
{
    public class FeatureRepository : IFeatureRepository
    {
        private readonly AppDbContext _context;

        public FeatureRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Feature> GetFeaturesForRole(string roleName)
        {
            var features = _context.RoleFeatureMappings
                .Where(rf => rf.Role.Name == roleName)
                .Select(rf => rf.Feature)
                .ToList();

            return features;
        }
    }
}
