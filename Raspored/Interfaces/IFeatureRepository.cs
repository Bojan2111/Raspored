using Raspored.Models;
using System.Collections.Generic;

namespace Raspored.Interfaces
{
    public interface IFeatureRepository
    {
        IEnumerable<Feature> GetFeaturesForRole(string roleName, int featureTypeId);
    }
}
