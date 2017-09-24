using System;
using System.Collections.Generic;
using BeProductive.Core.Domain;
using BeProductive.Core.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace BeProductive.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>
        {
            new User("user1@gmail.com","user1","secreT123456789","salt"),
            new User("user2@gmail.com","user2","secreT123456789","salt"),
            new User("user3@gmail.com","user3","secreT123456789","salt"),
            new User("user4@gmail.com","user4","secreT123456789","salt"),
            new User("user5@gmail.com","user5","secreT123456789","salt"),
        };

        public async Task AddAsync(User user)
        {
            _users.Add(user);
            await Task.CompletedTask;
        }

        public async Task<User> GetAsync(string email)
            => await Task.FromResult(_users.SingleOrDefault(x => x.Email == email.ToLowerInvariant()));

        public async Task<User> GetAsync(Guid id)
            => await Task.FromResult(_users.SingleOrDefault(x => x.Id == id));

        public async Task<IEnumerable<User>> GetAllAsync()
            => await Task.FromResult(_users);

        public async Task RemoveAsync(Guid id)
        {
            var user = await GetAsync(id);
            _users.Remove(user);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(User user)
        {
            await Task.CompletedTask;
        }
    }
}
