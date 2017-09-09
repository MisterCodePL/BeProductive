using System;

namespace BeProductive.Core.Domain
{
    public class Event
    {
        public Guid Id { get; protected set; }
        public Guid OwnerId { get; protected set; }
        public string Name { get; protected set; }
        public DateTime StartAt { get; protected set; }
        public DateTime EndAt { get; protected set; }
        public string Description { get; set; }


        protected Event()
        {
        }

        public Event(Guid ownerId, string name, DateTime startAt, DateTime endAt)
        {
            Id = Guid.NewGuid();
            SetOwnerId(ownerId);
            SetName(name);
            SetStartAt(startAt);
            SetEndAt(endAt);
        }

        protected void SetOwnerId(Guid ownerId)
        {
            if (ownerId == null) throw new ArgumentNullException();
            if (OwnerId == ownerId) return;
            OwnerId = ownerId;
        }

        public void SetName(string name)
        {
            if (Name == null) throw new ArgumentNullException();
            if (Name == name) return;
            Name = name;
        }

        public void SetStartAt(DateTime startAt)
        {
            if (startAt == null) throw new ArgumentNullException();
            if (StartAt == startAt) return;
            if (DateTime.Compare(startAt, EndAt) > 0)
                throw new Exception("Start time must be earlier than End time.");
            StartAt = startAt;
        }

        public void SetEndAt(DateTime endAt)
        {
            if (endAt == null) throw new ArgumentNullException();
            if (DateTime.Compare(StartAt, endAt) > 0)
                throw new Exception("End time must be later than Start time.");
            EndAt = endAt;
        }
    }
}