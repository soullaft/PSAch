using AutoMapper;
using PSAch.API.DTOs;
using PSAch.API.Models;

namespace PSAch.API.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<GameDto, Game>();
            CreateMap<Game, GameDto>();
        }
    }
}
