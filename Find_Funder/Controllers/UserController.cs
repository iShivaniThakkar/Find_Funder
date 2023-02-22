using FindFunder.Core.Contract;
using FindFunder.Core.Domain.RequestModel;
using FindFunder.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Find_Funder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) 
        {
            _userService= userService;
        }
        
        [HttpPost("adduser")]
        public async Task<IActionResult> AddUsers([FromForm] UserRequestModel user)
        {
            await _userService.AddUserAsync(user);
            return Created("Users", null);
        }

        [HttpGet("getusers")]
        public async Task<IActionResult> GetUsers(string? searchTerm = null, int page = 1, int pageSize = 25)
        {
            var users = await _userService.GetUserAsync(searchTerm, page, pageSize);
            return Ok(users);
        }

        [HttpGet("getuser/{userId}")]
        public async Task<IActionResult> GetUser(int userId)
        {
            var users = await _userService.GetIdByUserAsync(userId);
            return Ok(users);
        }
        [HttpPut("users/{userId}")]
        public async Task<IActionResult> UpdateStudent([FromForm]long userId, UserRequestModel model)
        {
            await _userService.UpdateUserAsync(userId, model);
            return Ok("User Updated Successfully.");
        }

    }
}
