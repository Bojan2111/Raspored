using AutoMapper;
using System.Collections.Generic;

namespace Raspored.Models.DTOs
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<Team, TeamDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<TeamMemberDTO, TeamDTO>()
                .ForMember(dest => dest.TeamMembers, opt => opt.MapFrom(src => new List<TeamMemberDTO>()));
        }
    }
}
