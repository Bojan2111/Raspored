using AutoMapper;

namespace Raspored.Models.DTOs
{
    public class ShiftProfile : Profile
    {
        public ShiftProfile()
        {
            CreateMap<Shift, ShiftDTO>()
                .ForMember(dest => dest.ShiftDate, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Month, opt => opt.MapFrom(src => src.Month))
                .ForMember(dest => dest.TeamMemberId, opt => opt.MapFrom(src => src.TeamMemberId))
                .ForMember(dest => dest.ShiftTypeName, opt => opt.MapFrom(src => src.ShiftType.Name))
                .ForMember(dest => dest.ShiftTypeDescription, opt => opt.MapFrom(src => src.ShiftType.Description));
        }
    }
}
