using System;
using System.Collections.Generic;

namespace Evento.Core.Domain
{
    public class Event : Entity
    {
        private ISet<Ticket> _tickets = new HashSet<Ticket>();

        public Event(Guid id, string name, string description,
         DateTime startdate, DateTime enddate)
        {
            Id = id;
            Name = name;
            Description = description;
            StartDate = startdate;
            EndDate = enddate;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
        private Event()
        {
        }

        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public IEnumerable<Ticket> Tickets => _tickets;

        public void AddTickets(int amount, decimal price)
        {
            var seating = _tickets.Count+1;
            for (int i = 0; i < amount; i++)
            {
                _tickets.Add(new Ticket(this, seating,  price));
                seating++;
            }

        }
    }
}