using BeProductive.Infrastructure.DTO;
using BeProductive.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public EventDto Get(Guid id)
          => _eventService.Get(id);
    }
}
