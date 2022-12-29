using AutoMapper;
using Data.Models.Models;
using Data.ViewModels;
using System.Numerics;

namespace Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CountryViewModel, Country >();
            CreateMap<Country, CountryViewModel>();
            CreateMap<CountryCharacteristicViewModel, CountryCharacteristic>();
            CreateMap<CountryCharacteristic, CountryCharacteristicViewModel>();

            
        }
    }
}