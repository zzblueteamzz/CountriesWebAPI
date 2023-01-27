using Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet]
        public List<string> GetAll()
        {
            return countryService.GetAll();
        }
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "User,Admin")]
        [HttpPost]
        public bool Create(CountryViewModel countryViewModel )
        {
            return countryService.Create( countryViewModel );
            
        }
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "User,Admin")]
        [HttpPut]
        public bool Update(CountryViewModel countryViewModel, string name)
        {
            return countryService.Update(countryViewModel, name);
        }
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "User,Admin")]
        [HttpDelete]
        public bool Delete(int id)
        {
           return countryService.Delete(id);
            
        }
    }
}
