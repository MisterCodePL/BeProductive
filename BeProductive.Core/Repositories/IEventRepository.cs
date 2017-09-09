using BeProductive.Core.Domain;
using System;
using System.Collections.Generic;

namespace BeProductive.Core.Repositories
{
    public interface IEventRepository
    {
        Event Get(Guid id);
        IEnumerable<Event> GetUserEvents(Guid ownerId);
        IEnumerable<Event> GetAll();
        void Add(Event _event);
        void Remove(Guid id);
        void Update(Event _event);
    }
}
