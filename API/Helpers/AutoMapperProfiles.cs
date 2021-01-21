using System.Linq;
using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
            .ForMember(
                m => m.PhotoUrl,
                opt => opt.MapFrom(
                    s => s.Photos.FirstOrDefault(x => x.IsMain).Url
                )
            )
            .ForMember(
                dest => dest.Age,
                opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge())
            );
            CreateMap<Photo, PhotoDto>();
        }
    }
}