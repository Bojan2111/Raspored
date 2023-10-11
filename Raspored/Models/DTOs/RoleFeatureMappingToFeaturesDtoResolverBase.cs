using AutoMapper;
using System.Collections.Generic;

namespace Raspored.Models.DTOs
{
    public class RoleFeatureMappingToFeaturesDtoResolver : IValueResolver<RoleFeatureMapping, FeaturesDTO, Dictionary<string, List<Feature>>>
    {
        public Dictionary<string, List<Feature>> Resolve(RoleFeatureMapping source, FeaturesDTO destination, Dictionary<string, List<Feature>> destMember, ResolutionContext context)
        {
            // Create your dictionary and populate it from source data
            var dictionary = new Dictionary<string, List<Feature>>
            {
                { source.FeatureType.Name, new List<Feature> { source.Feature } }
                // You can add more items to the dictionary if needed
            };

            return dictionary;
        }
    }
}