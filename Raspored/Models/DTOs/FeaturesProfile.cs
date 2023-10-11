using AutoMapper;
using System.Collections.Generic;

namespace Raspored.Models.DTOs
{
    public class FeaturesProfile : Profile
    {
        public FeaturesProfile()
        {
            CreateMap<RoleFeatureMapping, FeaturesDTO>()
                .ForMember(dest => dest.MenuOptions, opt => opt.MapFrom<RoleFeatureMappingToFeaturesDtoResolver>());
        }
    }
}
