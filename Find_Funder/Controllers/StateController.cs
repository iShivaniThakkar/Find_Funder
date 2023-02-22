using FindFunder.Core.Contract;
using FindFunder.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Find_Funder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly  IStateService _stateService;
        public StateController(IStateService stateService)
        {
            _stateService=stateService;

        }
        [HttpGet("getstates")]
        public async Task<IActionResult> GetStates(string? searchTerm = null, int page = 1, int pageSize = 25)
        {
            var states = await _stateService.GetStatesAsync(searchTerm, page, pageSize);
            return Ok(states);
        }

    }
}
