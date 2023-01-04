using AutoMapper;
using Data.Context;
using Data.Models.Models;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CountryCharacteristicServices
{
    public class CountryCharacteristicService : ICountryCharacteristicService<CountryCharacteristicViewModel>
    {
        private readonly CountriesContext countriesContext;
        private readonly IMapper mapper;
        public CountryCharacteristicService(CountriesContext countriesContext, IMapper mapper)
        {
            this.countriesContext = countriesContext;
            this.mapper = mapper;
        }
        public bool Create(CountryCharacteristicViewModel viewModel)
        {
            var countryChara = mapper.Map<CountryCharacteristic>(viewModel);
            countriesContext.Add(countryChara);
            countriesContext.SaveChanges();
            return true;

        }

        public bool Delete(int id)
        {
            var countryChara = countriesContext.CountriesCharacteristics.Find(id);
            countriesContext.CountriesCharacteristics.Remove(countryChara);
            countriesContext.SaveChanges();
            return true;
        }

        public bool Update(CountryCharacteristicViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
