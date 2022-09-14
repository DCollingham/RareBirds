using AutoMapper;
using RareBirdsApi.Models;
using RareBirdsApi.Models.DTOs;

namespace RareBirdsApi.Configs
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Bird, GETBirdDetailsDTO>().ReverseMap();
            CreateMap<Bird, GETBirdsDTO>().ReverseMap();
            CreateMap<Sighting, GetSightingDTO>().ReverseMap();
        }
    }
}
