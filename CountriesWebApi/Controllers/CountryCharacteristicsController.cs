using Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.CountryCharacteristicServices;
using Services.CountryServices;

namespace CountriesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryCharacteristicsController : ControllerBase
    {
        private readonly ICountryCharacteristicService<CountryCharacteristicViewModel> countryCharacteristicService;
        public CountryCharacteristicsController(ICountryCharacteristicService<CountryCharacteristicViewModel> countryCharacteristicService)
        {
            this.countryCharacteristicService = countryCharacteristicService;
        }
        [HttpPost]
        public bool Create(CountryCharacteristicViewModel countryCharacteristicViewModel)
        {
            return countryCharacteristicService.Create(countryCharacteristicViewModel);

        }
        [HttpDelete]
        public bool Delete(int id)
        {
            return countryCharacteristicService.Delete(id);

        }
    }
}
