using AutoMapper;
using Data.Models.Models;
using Data.ViewModels;

namespace Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CountryViewModel, Country>()
                  .ForMember(dest => dest.Name, act => act.MapFrom(src => src.CountryName))
                  .ForMember(dest => dest.Area, act => act.MapFrom(src => src.Area))
                  .ForMember(dest=>dest.Population,act=>act.MapFrom(src=>src.Population));

            CreateMap<RegionViewModel, Region>()
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.RegionName))
                .ForMember(dest => dest.Birtrate, act => act.MapFrom(src => src.Birthrate))
                .ForMember(dest => dest.Deathrate, act => act.MapFrom(src => src.Deathrate));
        }
    }
}