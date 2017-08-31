using BeProductive.Infrastructure.DTO;
using BeProductive.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

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
        public UserDto Get(string email)
          => _userService.Get(email);
    }
}
