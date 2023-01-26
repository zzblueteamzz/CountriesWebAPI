using Data.Models.Models;
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
        [HttpGet]
        public List<CountryCharacteristicViewModel> GetAll()
        {
            return countryCharacteristicService.GetAll();
        }
        [HttpPost]
        public bool Create(CountryCharacteristicViewModel countryCharacteristicViewModel)
        {
            return countryCharacteristicService.Create(countryCharacteristicViewModel);

        }
        [HttpPut]
        public bool Update(CountryCharacteristicViewModel countryCharacteristicViewModel, string name)
        {
            return countryCharacteristicService.Update(countryCharacteristicViewModel, name);
        }
        [HttpDelete]
        public bool Delete(int id)
        {
            return countryCharacteristicService.Delete(id);
        }
    }
}
