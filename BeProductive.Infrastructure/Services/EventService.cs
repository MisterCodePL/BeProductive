using System;
using System.Collections.Generic;
using System.Text;
using BeProductive.Infrastructure.DTO;
using BeProductive.Core.Repositories;
using BeProductive.Core.Domain;

namespace BeProductive.Infrastructure.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public void Add(Guid ownerId, string name, DateTime startAt, DateTime endAt)
        {
            var _event = new Event(ownerId, name, startAt, endAt);
            _eventRepository.Add(_event);
        }

        public EventDto Get(Guid id)
        {
            var _event = _eventRepository.Get(id);
            return new EventDto
            {
                Id = _event.Id,
                Name = _event.Name,
                Description = _event.Description,
                EndAt = _event.EndAt,
                OwnerId = _event.OwnerId,
                StartAt = _event.StartAt
            };
        }
    }
}
