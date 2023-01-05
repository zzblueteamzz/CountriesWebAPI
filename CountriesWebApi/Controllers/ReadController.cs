using Data.Context;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Reflection;

namespace CountriesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadController : ControllerBase
    {
        public readonly ICsvService _csvService;
        public ReadController(ICsvService csvService)
        {
            _csvService = csvService;

        }
        //public CountriesContext CountriesContext { get; set; }
        //public ReadController(CountriesContext context)
        //{
        //    CountriesContext = context;
        //}
        //public List<PopulationModel> PopulationModels { get; set; }
        //[HttpGet]
        //public void ReadData()
        //{
        //    ICsvService csvService = new CsvService();
        //    var dir = Assembly.GetExecutingAssembly().Location;

        //     var filepath = Path.GetDirectoryName(dir);
        //    var fullDir = Path.Combine(filepath, "Population.csv");


        //    var res = csvService.ReadTradesFromFile(fullDir);

        //    PopulationModels = res;
        //}
        [HttpGet]
        public Task ReadData()
        {
            var dir = Assembly.GetExecutingAssembly().Location;
            var filepath = Path.GetDirectoryName(dir);
            var fullDir = Path.Combine(filepath, "Population.csv");
            return _csvService.CsvDataFilling(_csvService.ReadTradesFromFile(fullDir));
        }
    }
}
