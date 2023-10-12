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
            var features = _context.RoleFeatureMappings
                .Where(rf => rf.Role.Name == roleName).ProjectTo<FeaturesDTO>(_mapper.ConfigurationProvider)
                .ToList();

            return features;
        }
    }
}
