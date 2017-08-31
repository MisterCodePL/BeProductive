using BeProductive.Core.Domain;
using BeProductive.Core.Repositories;
using System;
using BeProductive.Infrastructure.DTO;

namespace BeProductive.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDto Get(string email)
        {
            var user = _userRepository.Get(email);
            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.Username,
                FullName = user.FullName,
                CreatedAt = user.CreatedAt,
                Events = user.Events
            };       
        }

        public void Register(string email, string username, string password)
        {
            var user = _userRepository.Get(email);
            if(user!=null)
            {
                throw new Exception($"User with email: {email} already exist.");
            }

            var salt = Guid.NewGuid().ToString("N");
            user = new User(email, username, password, salt);
            _userRepository.Add(user);
        }
    }
}
