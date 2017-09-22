using System;

namespace BeProductive.Infrastructure.DTO
{
    public class EventDto
    {
        public Guid Id { get;  set; }
        public Guid OwnerId { get;  set; }
        public string Name { get;  set; }
        public DateTime StartAt { get;  set; }
        public DateTime EndAt { get;  set; }
        public string Description { get;  set; }
    }
}
