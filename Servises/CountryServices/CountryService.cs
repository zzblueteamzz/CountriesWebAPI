using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.Context;
using Data.Models.Models;
using Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Services.CountryServices
{
    public class CountryService: ICountryService<CountryViewModel>
    {
        private readonly CountriesContext countriesContext;
        private readonly IMapper mapper;
        public CountryService(CountriesContext countriesContext, IMapper mapper)
        {
            this.countriesContext = countriesContext;
            this.mapper = mapper;
        }
        public List<string> GetAll()
        {
            List<string> list = new List<string>();
            List<Country> result = countriesContext.Countries.ToList();
            foreach (Country country in result)
            {
                var newCountry = mapper.Map<CountryViewModel>(country);
                string json = JsonSerializer.Serialize(newCountry).ToString();
                list.Add(json);
            }
            return list;

        }
        public  bool Create(CountryViewModel viewModel)
        {   bool isExCountry=countriesContext.Countries.Select(p=>p.CountryName).Contains(viewModel.CountryName);
            var country = mapper.Map<Country>(viewModel);
            if (isExCountry)
            {
                return false;
            }
            else
            {
                
                countriesContext.Add(country);
                countriesContext.SaveChanges();
                return true;
            }
           
            
        }
        public bool Update(CountryViewModel viewModel,string name)
        {
            Country? country = countriesContext.Countries.Where(c => c.CountryName == name).FirstOrDefault();
            if(country == null)
            {
                return false;
            }

            country.CountryName = viewModel.CountryName;
            countriesContext.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            Country? country =  countriesContext.Countries.Find(id);
            if (country == null)
            {
                return false;
            }
            CountryCharacteristic? countryCharacteristic=countriesContext.CountriesCharacteristics.Where(p=>p.CountryId==id).FirstOrDefault();
            if (countryCharacteristic!=null)
            {
                countriesContext.Remove(countryCharacteristic);
            }
            countriesContext.Countries.Remove(country);
             countriesContext.SaveChanges();
            return true;
        }
       
    }
}