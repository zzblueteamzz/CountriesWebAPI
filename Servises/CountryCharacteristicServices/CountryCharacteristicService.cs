using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.Context;
using Data.Models.Models;
using Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        public List<CountryCharacteristicViewModel>  GetAll()
        {   
            List<CountryCharacteristicViewModel> countryList = new List<CountryCharacteristicViewModel>();
            List<CountryCharacteristic> result = countriesContext.CountriesCharacteristics.ToList();
            foreach (var country in result)
            {
               var newCountry= mapper.Map<CountryCharacteristicViewModel>(country);
                countryList.Add(newCountry);
            }
            return countryList;
           
        }
        public bool Create(CountryCharacteristicViewModel viewModel)
        {

            Country? country = countriesContext.Countries.Where(p => p.CountryName == viewModel.Country).FirstOrDefault();
            var countryChara = mapper.Map<CountryCharacteristic>(viewModel);
            
            if (country != null)
            {
                countryChara.CountryId = country.Id;
                countriesContext.Add(countryChara);
                countriesContext.SaveChanges();
                return true;
            }
            
            
            return false;

        }
        public bool Update(CountryCharacteristicViewModel viewModel, string name)
        {
            int countryId = countriesContext.Countries.Where(c => c.CountryName == name).FirstOrDefault()?.Id??0;
            if (countryId != 0)
            {
                CountryCharacteristic? characteristic = countriesContext.CountriesCharacteristics.Where(x => x.CountryId == countryId).FirstOrDefault();
                if(characteristic == null)
                {
                    return false;
                }
                characteristic.YearlyChange = viewModel.YearlyChange;
                characteristic.NetChange = viewModel.NetChange;
                characteristic.Density=viewModel.Density;
                characteristic.LandArea = viewModel.LandArea;
                characteristic.FertRate = viewModel.FertRate;               
                characteristic.MedAge = viewModel.MedAge;
                characteristic.WorldShare=viewModel.WorldShare;


                countriesContext.SaveChanges();
                return true;
            }
            return false;
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
