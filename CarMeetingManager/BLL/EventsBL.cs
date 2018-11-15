using AutoMapper;
using CarMeetingManager.BLL.DTO;
using CarMeetingManager.DAL;
using CarMeetingManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarMeetingManager.BLL
{
    public class EventsBL
    {
        private CarMeetingContext _context;
        List<EventDTO> Events = new List<EventDTO>();
        IMeetingRepository Repository;

        public EventsBL(CarMeetingContext context)
        {
            _context = context;
            Repository = new MeetingRepository(context);
        }

        public IEnumerable<EventDTO> GetAllEvents()
        {
            List<Event> list = Repository.GetAllEvents().ToList();
            foreach (var item in list)
            {
                EventDTO eve = Mapper.Map<EventDTO>(item);
                Events.Add(eve);
            }
            return Events;
        }

        public EventDTO GetEventById(int id)
        {
            Event e = Repository.GetEventById(id);
            return Mapper.Map<EventDTO>(e);
        }
        
    }
}
