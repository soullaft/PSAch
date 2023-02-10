using AutoMapper;
using PSAch.API.DTOs;
using PSAch.Core;

namespace PSAch.API.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<GameDto, Game>().ReverseMap();
            CreateMap<AchievementDto, Achievement>().ReverseMap();
        }
    }
}
