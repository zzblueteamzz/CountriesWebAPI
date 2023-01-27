using Data.Models.Models;
using Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.CountryCharacteristicServices;
using Services.CountryServices;
using System.Data;

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
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "User,Admin")]
        [HttpPost]
        public bool Create(CountryCharacteristicViewModel countryCharacteristicViewModel)
        {
            return countryCharacteristicService.Create(countryCharacteristicViewModel);

        }
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "User,Admin")]
        [HttpPut]
        public bool Update(CountryCharacteristicViewModel countryCharacteristicViewModel, string name)
        {
            return countryCharacteristicService.Update(countryCharacteristicViewModel, name);
        }
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete]
        public bool Delete(int id)
        {
            return countryCharacteristicService.Delete(id);
        }
    }
}
