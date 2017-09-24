using BeProductive.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeProductive.Core.Repositories
{
    public interface IEventRepository
    {
        Task<Event> GetAsync(Guid id);
        Task<IEnumerable<Event>> GetUserEventsAsync(Guid ownerId);
        Task<IEnumerable<Event>> GetAllAsync();
        Task AddAsync(Event _event);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(Event _event);
    }
}
