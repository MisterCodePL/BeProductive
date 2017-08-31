using BeProductive.Core.Domain;
using System;
using System.Collections.Generic;

namespace BeProductive.Infrastructure.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public DateTime CreatedAt { get; set; }

        public IEnumerable<Event> Events { get; set; }
    }
}
