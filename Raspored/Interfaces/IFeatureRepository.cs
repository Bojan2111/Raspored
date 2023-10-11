using Raspored.Models;
using Raspored.Models.DTOs;
using System.Collections.Generic;

namespace Raspored.Interfaces
{
    public interface IFeatureRepository
    {
        IEnumerable<FeaturesDTO> GetFeaturesForRole(string roleName);
    }
}
