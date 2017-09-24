using System;
using BeProductive.Infrastructure.DTO;
using BeProductive.Core.Repositories;
using BeProductive.Core.Domain;
using AutoMapper;
using System.Threading.Tasks;

namespace BeProductive.Infrastructure.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventService(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(Guid ownerId, string name, DateTime startAt, DateTime endAt)
        {
            var _event = new Event(ownerId, name, startAt, endAt);
            await _eventRepository.AddAsync(_event);
        }

        public async Task<EventDto> GetAsync(Guid id)
        {
            var _event = await _eventRepository.GetAsync(id);
            return _mapper.Map<Event, EventDto>(_event);
        }
    }
}
