using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Raspored.Interfaces;
using Raspored.Models;
using Raspored.Models.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Raspored.Repositories
{
    public class FeatureRepository : IFeatureRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public FeatureRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<FeaturesDTO> GetFeaturesForRole(string roleName)
        {
            var roleFeatureMappings = _context.RoleFeatureMappings
            .Include(rf => rf.FeatureType)
            .Where(rf => rf.Role.Name == roleName)
            .ToList();

            var featuresDictionary = new Dictionary<string, List<Feature>>();

            foreach (var mapping in roleFeatureMappings)
            {
                var featureType = mapping.FeatureType.Name;

                // If the featureType is not in the dictionary, create a new entry
                if (!featuresDictionary.ContainsKey(featureType))
                {
                    featuresDictionary[featureType] = new List<Feature>();
                }

                // Add the feature to the corresponding list in the dictionary
                featuresDictionary[featureType].Add(mapping.Feature);
            }

            // Create FeaturesDTO with the constructed dictionary
            var featuresDto = new FeaturesDTO
            {
                MenuOptions = featuresDictionary
            };

            // Return the DTO in a list or as needed
            return new List<FeaturesDTO> { featuresDto };
            //var features = _context.RoleFeatureMappings
            //    .Where(rf => rf.Role.Name == roleName).ProjectTo<FeaturesDTO>(_mapper.ConfigurationProvider)
            //    .ToList();

            //return features;
        }
    }
}
