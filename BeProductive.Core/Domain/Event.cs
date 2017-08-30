using System;

namespace BeProductive.Core.Domain
{
    public class Event
    {
        public Guid Id { get; private set; }
        public Guid OwnerId { get; private set; }
        public string Name { get; private set; }
        public DateTime StartAt { get; private set; }
        public DateTime EndAt { get; private set; }
        public string Description { get; private set; }


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

        private void SetOwnerId(Guid ownerId)
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