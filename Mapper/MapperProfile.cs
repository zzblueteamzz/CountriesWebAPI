using AutoMapper;
using Data.Models.Models;
using Data.ViewModels;
using Data.ViewModels.AuthenticateModels;
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

            CreateMap<AuthenticateRequest, User>();
            CreateMap<User, AuthenticateRequest>();

            CreateMap<AuthenticateResponse, User>();
            CreateMap<User, AuthenticateResponse>();

            CreateMap<RegisterRequest, User>();
            CreateMap<User, RegisterRequest>();

            CreateMap<UpdateRequest, User>();
            CreateMap<User, UpdateRequest>();


        }
    }
}