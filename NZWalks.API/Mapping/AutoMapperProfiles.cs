using AutoMapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<Region, AddRegionRequestDTO>().ReverseMap();
            CreateMap<Region, UpdateNewRegionDTO>().ReverseMap();
            CreateMap<Walk, AddWalksDTO>().ReverseMap();
            CreateMap<Walk, UpdateWalkDTO>().ReverseMap();
            CreateMap<WalkDTO, Walk>().ReverseMap();
            CreateMap<Difficulty, DifficultyDTO>().ReverseMap();
        }
    }
}
