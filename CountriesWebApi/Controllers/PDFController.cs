using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.PDFServices;

namespace CountriesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PDFController : ControllerBase
    {
        private readonly IPDFService _pDFService;
        public PDFController(IPDFService pDFService)
        {
            _pDFService = pDFService;
        }   
        [HttpGet]
        public IActionResult PDF()
        {
            return _pDFService.PDfSample();
        }
    }
}
