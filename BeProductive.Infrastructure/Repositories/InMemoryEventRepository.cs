using System;
using System.Collections.Generic;
using BeProductive.Core.Domain;
using BeProductive.Core.Repositories;
using System.Linq;

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

        public void Add(Event _event)
        {
            _events.Add(_event);
        }

        public Event Get(Guid id)
            => _events.Single(x => x.Id == id);

        public IEnumerable<Event> GetAll()
            => _events;

        public IEnumerable<Event> GetUserEvents(Guid ownerId)
            => _events.Where(x => x.OwnerId == ownerId);

        public void Remove(Guid id)
        {
            _events.Remove(Get(id));
        }

        public void Update(Event _event)
        {
        }
    }
}
