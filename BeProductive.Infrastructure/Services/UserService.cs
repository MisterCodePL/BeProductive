﻿using BeProductive.Core.Domain;
using BeProductive.Core.Repositories;
using System;
using BeProductive.Infrastructure.DTO;
using AutoMapper;
using System.Threading.Tasks;

namespace BeProductive.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> GetAsync(string email)
        {
            var user = await _userRepository.GetAsync(email);
            return _mapper.Map<User, UserDto>(user);    
        }

        public async Task RegisterAsync(string email, string username, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if(user!=null)
            {
                throw new Exception($"User with email: {email} already exist.");
            }

            var salt = Guid.NewGuid().ToString("N");
            user = new User(email, username, password, salt);
            await _userRepository.AddAsync(user);
        }
    }
}
