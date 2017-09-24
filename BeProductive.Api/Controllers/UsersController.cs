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
    }
}
