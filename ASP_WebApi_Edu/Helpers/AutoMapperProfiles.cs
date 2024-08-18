using ASP_WebApi_Edu.Extensions;
using ASP_WebApi_Edu.Models.Domain;
using ASP_WebApi_Edu.Models.DTO;
using AutoMapper;

namespace ASP_WebApi_Edu.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Configures PhotoUrl to map from AppUser's main photo URL
            // and Age to calculate from DateOfBirth.
            CreateMap<AppUser, MemberDto>()
                .ForMember(dest => dest.PhotoUrl,
                opt => opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));

            CreateMap<Photo, PhotoDto>();
            CreateMap<MemberUpdateDto, AppUser>();
            CreateMap<RegisterUserDto, AppUser>();

            // Configures SenderPhotoUrl to map from Sender's main photo URL
            // and RecepientPhotoUrl to map from Recepient's main photo URL.
            CreateMap<Message, MessageDto>()
                .ForMember(d => d.SenderPhotoUrl,
                o => o.MapFrom(d => d.Sender.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(d => d.RecepientPhotoUrl,
                o => o.MapFrom(d => d.Recepient.Photos.FirstOrDefault(p => p.IsMain).Url));

            CreateMap<DateTime, DateTime>().ConvertUsing(d => DateTime.SpecifyKind(d, DateTimeKind.Utc));
            CreateMap<DateTime?, DateTime?>().ConvertUsing(d => d.HasValue ?
                DateTime.SpecifyKind(d.Value, DateTimeKind.Utc) : null);
        }
    }
}
