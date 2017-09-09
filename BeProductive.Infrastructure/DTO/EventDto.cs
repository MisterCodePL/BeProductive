using System;

namespace BeProductive.Infrastructure.DTO
{
    public class EventDto
    {
        public Guid Id { get; protected set; }
        public Guid OwnerId { get; protected set; }
        public string Name { get; protected set; }
        public DateTime StartAt { get; protected set; }
        public DateTime EndAt { get; protected set; }
        public string Description { get; protected set; }
    }
}
