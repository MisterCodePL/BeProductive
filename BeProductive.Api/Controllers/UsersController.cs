using BeProductive.Infrastructure.Commands.Users;
using BeProductive.Infrastructure.DTO;
using BeProductive.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BeProductive.Api.Controllers
{
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{email}")]
        public async Task<UserDto> GetAsync(string email)
          => await _userService.GetAsync(email);

        [HttpPost("")]
        public async Task PostAsync(CreateUser request)
        {
            await _userService.RegisterAsync(request.Email, request.Username, request.Password);
        }
    }
}
