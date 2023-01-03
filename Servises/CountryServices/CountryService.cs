using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.Context;
using Data.Models.Models;
using Data.ViewModels;
using Microsoft.EntityFrameworkCore;

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
        public bool Update(CountryViewModel viewModel)
        {
            var country = mapper.Map<Country>(viewModel);
            countriesContext.Update(country);
             countriesContext.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var country =  countriesContext.Countries.Find(id);
            countriesContext.Countries.Remove(country);
             countriesContext.SaveChanges();
            return true;
        }
        public async Task<T> GetAsync<T>(int id)
        {

            return await countriesContext.Countries.Where(s => s.Id == id).ProjectTo<T>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }
    }
}