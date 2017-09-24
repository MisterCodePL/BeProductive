using System;
using System.Collections.Generic;
using BeProductive.Core.Domain;
using BeProductive.Core.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace BeProductive.Infrastructure.Repositories
{
    public class InMemoryEventRepository : IEventRepository
    {
        private static ISet<Event> _events = new HashSet<Event>
        {
            new Event(Guid.NewGuid(), "event1", DateTime.Now, DateTime.Now.AddDays(1)),
            new Event(Guid.NewGuid(), "event2", DateTime.Now.AddDays(1),DateTime.Now.AddDays(2)),
            new Event(Guid.NewGuid(), "event3", DateTime.Now.AddDays(2),DateTime.Now.AddDays(3)),
            new Event(Guid.NewGuid(), "event4", DateTime.Now.AddDays(3),DateTime.Now.AddDays(4)),
            new Event(Guid.NewGuid(), "event5", DateTime.Now.AddDays(4),DateTime.Now.AddDays(5))
        };

        public async Task AddAsync(Event _event)
        {
            _events.Add(_event);
            await Task.CompletedTask;
        }

        public async Task<Event> GetAsync(Guid id)
            => await Task.FromResult(_events.SingleOrDefault(x => x.Id == id));

        public async Task<IEnumerable<Event>> GetAllAsync()
            => await Task.FromResult(_events);

        public async Task<IEnumerable<Event>> GetUserEventsAsync(Guid ownerId)
            => await Task.FromResult(_events.Where(x => x.OwnerId == ownerId));

        public async Task RemoveAsync(Guid id)
        {
            _events.Remove(await GetAsync(id));
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Event _event)
        {
            await Task.CompletedTask;
        }
    }
}
