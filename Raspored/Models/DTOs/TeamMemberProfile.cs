using AutoMapper;

namespace Raspored.Models.DTOs
{
    public class TeamMemberProfile : Profile
    {
        public TeamMemberProfile()
        {
            CreateMap<TeamMember, TeamMemberDTO>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.User.LastName} {src.User.FirstName}"))
               .ForMember(dest => dest.YearOfEmployment, opt => opt.MapFrom(src => src.User.YearOfEmployment))
               .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.User.Position.Name))
               .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team.Name))
               .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.TeamMemberRole.Name));
        }
    }
}
