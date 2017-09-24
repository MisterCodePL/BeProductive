using BeProductive.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeProductive.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(string email);
        Task<User> GetAsync(Guid id);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(User user);
    }
}
