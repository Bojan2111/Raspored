using AutoMapper;
using System.Collections.Generic;

namespace Raspored.Models.DTOs
{
    public class FeaturesProfile : Profile
    {
        public FeaturesProfile()
        {
            CreateMap<RoleFeatureMapping, FeaturesDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Feature.Id))
                .ForMember(dest => dest.Menu, opt => opt.MapFrom(src => src.FeatureType.Name))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Feature.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Feature.Description));
        }
    }
}
