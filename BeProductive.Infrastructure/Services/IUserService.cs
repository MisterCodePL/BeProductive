﻿
namespace BeProductive.Infrastructure.Services
{
    public interface IUserService
    {
        void Register(string email, string username, string password);
    }
}