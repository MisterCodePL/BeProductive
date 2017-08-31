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
        public string Description { get; protected set; }


        protected Event()
        {
        }

        public Event(Guid ownerId, string name, DateTime startAt, DateTime endAt)
        {
            SetOwnerId(ownerId);
            SetName(name);
            SetStartAt(startAt);
            SetEndAt(endAt);
        }

        protected void SetOwnerId(Guid ownerId)
        {
            if (ownerId != null) OwnerId = ownerId;
            else throw new NullReferenceException();
        }

        public void SetName(string name)
        {
            if (Name != null) Name = name;
            else throw new NullReferenceException();
        }

        public void SetStartAt(DateTime startAt)
        {
            StartAt = startAt;
        }

        public void SetEndAt(DateTime endAt)
        {
            if (endAt == null) throw new NullReferenceException();
            if (DateTime.Compare(StartAt, endAt) < 0) EndAt = endAt;
            else throw new Exception("End time must be later than Start time.");
        }
    }
}