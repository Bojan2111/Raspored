using AutoMapper;
using Raspored.Models.Login;

namespace Raspored.Models.DTOs
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<NotificationMapping, NotificationDTO>()
                .ForMember(dest => dest.Receiver, opt => opt.MapFrom(src => $"{src.Sender.FirstName} {src.Sender.LastName}"))
                .ForMember(dest => dest.Sender, opt => opt.MapFrom(src => $"{src.Receiver.FirstName} {src.Receiver.LastName}"));

            CreateMap<Notification, NotificationDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.Unread, opt => opt.MapFrom(src => src.Unread));
        }
    }
}
