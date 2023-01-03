using Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.CountryServices;

namespace CountriesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService<CountryViewModel> countryService;
        public CountriesController(ICountryService<CountryViewModel> countryService)
        {
            this.countryService = countryService;
        }
        [HttpPost]
        public bool Create(CountryViewModel countryViewModel )
        {
            return countryService.Create( countryViewModel );
            
        }
        [HttpPut]
        public bool Update(CountryViewModel countryViewModel)
        {
            return countryService.Update(countryViewModel);
        }
        [HttpDelete]
        public bool Delete(int id)
        {
           return countryService.Delete(id);
            
        }
    }
}
