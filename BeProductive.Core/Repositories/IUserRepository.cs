using BeProductive.Core.Domain;
using System;
using System.Collections.Generic;

namespace BeProductive.Core.Repositories
{
    public interface IUserRepository
    {
        User Get(string email);
        User Get(Guid id);
        IEnumerable<User> GetAll();
        void Add(User user);
        void Remove(Guid id);
        void Update(User user);
    }
}
