using FindFunder.Core.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Find_Funder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        public CityController(ICityService cityService)
        {
            _cityService = cityService;

        }
        [HttpGet("getcities")]
        public async Task<IActionResult> GetCities(string? searchTerm = null, int page = 1, int pageSize = 25)
        {
            var cities = await _cityService.GetCitiesAsync(searchTerm, page, pageSize);
            return Ok(cities);
        }
    }
}
