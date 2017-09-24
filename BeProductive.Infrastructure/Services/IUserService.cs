using BeProductive.Infrastructure.DTO;
using System.Threading.Tasks;

namespace BeProductive.Infrastructure.Services
{
    public interface IUserService
    {
        Task RegisterAsync(string email, string username, string password);
        Task<UserDto> GetAsync(string email);
    }
}
