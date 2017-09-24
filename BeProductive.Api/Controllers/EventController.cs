using BeProductive.Infrastructure.DTO;
using BeProductive.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BeProductive.Api.Controllers
{
    [Route("[controller]")]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet("{email}")]
        public async Task<EventDto> GetAsync(Guid id)
          => await _eventService.GetAsync(id);
    }
}
