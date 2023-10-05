using AutoMapper;
using Raspored.Models.Login;

namespace Raspored.Models.DTOs
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<NotificationMapping, NotificationDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.NotificationId))
                .ForMember(dest => dest.ReceiverId, opt => opt.MapFrom(src => src.ReceiverId))
                .ForMember(dest => dest.SenderId, opt => opt.MapFrom(src => src.SenderId))
                .ForMember(dest => dest.Receiver, opt => opt.MapFrom(src => $"{src.Sender.FirstName} {src.Sender.LastName}"))
                .ForMember(dest => dest.Sender, opt => opt.MapFrom(src => $"{src.Receiver.FirstName} {src.Receiver.LastName}"))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Notification.Title))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Notification.Content))
                .ForMember(dest => dest.Unread, opt => opt.MapFrom(src => src.Notification.Unread));
        }
    }
}
