using BeProductive.Infrastructure.DTO;
using System;
using System.Threading.Tasks;

namespace BeProductive.Infrastructure.Services
{
    public interface IEventService
    {
        Task AddAsync(Guid ownerId, string name, DateTime startAt, DateTime endAt);
        Task<EventDto> GetAsync(Guid id);
    }
}
