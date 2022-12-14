using AutoMapper;
using RareBirdsApi.Data.Birds;
using RareBirdsApi.Data.Sightings;

namespace RareBirdsApi.Configs
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Bird, GetBirdDetailsDTO>().ReverseMap();
            CreateMap<Bird, GetBirdsDTO>().ReverseMap();
            CreateMap<Bird, PostBirdDTO>().ReverseMap();
            CreateMap<Bird, GetBirdDTO>().ReverseMap();
            CreateMap<Bird, PutBirdDTO>().ReverseMap();

            CreateMap<Sighting, GetSightingDTO>().ReverseMap();
            CreateMap<Sighting, PostSightingDTO>().ReverseMap();
            CreateMap<Sighting, PutSightingDTO>().ReverseMap();
        }
    }
}
