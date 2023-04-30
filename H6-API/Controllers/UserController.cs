using H6_API.Domain.Entites;
using H6_API.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace H6_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(string id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            var userDto = new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
            };

            return Ok(userDto);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser(CreateUserDto createUserDto)
        {
            var user = new ApplicationUser
            {
                UserName = createUserDto.UserName,
            };

            var result = await _userService.CreateUserAsync(user, createUserDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var userDto = new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
            };

            return CreatedAtAction(nameof(GetUserById), new { id = userDto.Id }, userDto);
        }
    }

    public class CreateUserDto : UserDto
    {
        public string Password { get; set; }
    }

    public class UserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
    }
}
