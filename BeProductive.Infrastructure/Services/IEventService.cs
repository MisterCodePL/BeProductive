using BeProductive.Infrastructure.DTO;
using System;

namespace BeProductive.Infrastructure.Services
{
    public interface IEventService
    {
        void Add(Guid ownerId, string name, DateTime startAt, DateTime endAt);
        EventDto Get(Guid id);
    }
}
