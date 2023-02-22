using FindFunder.Core.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Find_Funder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;

        }
        [HttpGet("getcountries")]
        public async Task<IActionResult> GetCountries(string? searchTerm=null,int page=1,int pageSize=25)
        {
            var countries=await _countryService.GetCountryAsync(searchTerm,page,pageSize);
            return Ok(countries);
        }
      
    }
}
