using CarMeetingManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarMeetingManager.DAL
{
    public class EventsDA
    {
        protected CarMeetingContext Context { get; set; }

        public EventsDA(CarMeetingContext context)
        {
            this.Context = context;
        }

        public List<Event> GetAllEvents()
        {
            return Context.Events.ToList();
        }

        public Event GetEventById(int id)
        {
            if (id != 0)
            {
                return Context.Events.Where(e => e.EventId == id).SingleOrDefault();
            }
            return null;
        }

        public List<Event> GetEventsByTypeId(int id)
        {
            return Context.Events.Where(e => e.EventTypeId == id).ToList();
        }

    }
}
