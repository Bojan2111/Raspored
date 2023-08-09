using AutoMapper;
using Raspored.Models.Login;
using System.Collections.Generic;

namespace Raspored.Models.DTOs
{
    public class PersonalScheduleProfile : Profile
    {
        public PersonalScheduleProfile()
        {
            CreateMap<Team, PersonalSchedule>()
            .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Name));

            CreateMap<TeamMember, PersonalSchedule>()
                .ForMember(dest => dest.TeamMemberId, opt => opt.MapFrom(src => src.Id));

            CreateMap<ApplicationUser, PersonalSchedule>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName));

            CreateMap<TeamMemberRole, PersonalSchedule>()
                .ForMember(dest => dest.TeamMemberRoleName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.TeamMemberRoleDescription, opt => opt.MapFrom(src => src.Description));

            CreateMap<Shift, ShiftDTO>()
                .Include<Shift, ShiftDTO>();

            CreateMap<Shift, PersonalSchedule>()
                .ForMember(dest => dest.Shifts, opt => opt.MapFrom(src => src));

            //CreateMap<Shift, ShiftDTO>()
            //    .ForMember(dest => dest.ShiftTypeName, opt => opt.MapFrom(src => src.ShiftType.Name))
            //    .ForMember(dest => dest.ShiftTypeDescription, opt => opt.MapFrom(src => src.ShiftType.Description));

            //CreateMap<ShiftDTO, PersonalSchedule>()
            //    .ForMember(dest => dest.Shifts, opt => opt.MapFrom(src => new List<ShiftDTO> { src }));
        }
    }
}
