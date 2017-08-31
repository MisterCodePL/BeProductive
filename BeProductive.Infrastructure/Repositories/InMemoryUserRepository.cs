using System;
using System.Collections.Generic;
using BeProductive.Core.Domain;
using BeProductive.Core.Repositories;
using System.Linq;

namespace BeProductive.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>
        {
            new User("user1@gmail.com","user1","secret123456789","salt"),
            new User("user2@gmail.com","user2","secret123456789","salt"),
            new User("user3@gmail.com","user3","secret123456789","salt"),
            new User("user4@gmail.com","user4","secret123456789","salt"),
            new User("user5@gmail.com","user5","secret123456789","salt"),
        };

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User Get(string email)
            => _users.Single(x => x.Email == email.ToLowerInvariant());

        public User Get(Guid id)
            => _users.Single(x => x.Id == id);

        public IEnumerable<User> GetAll()
            => _users;

        public void Remove(Guid id)
        {
            var user = Get(id);
            _users.Remove(user);
        }

        public void Update(User user)
        {
        }
    }
}
