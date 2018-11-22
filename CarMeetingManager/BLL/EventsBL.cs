using AutoMapper;
using CarMeetingManager.BLL.DTO;
using CarMeetingManager.BLL.Interfaces;
using AutoMapper.QueryableExtensions;
using CarMeetingManager.DAL;
using CarMeetingManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarMeetingManager.BLL
{
    public class EventsBL : IEventsBL
    {
        List<EventDTO> Events = new List<EventDTO>();
        IMeetingRepository Repository;
        IMapper _mapper;

        public EventsBL(IMeetingRepository repo, IMapper mapper)
        {
            Repository = repo;
            _mapper = mapper;
        }

        //Get all events from DAL. Map them to DTO model
        public List<EventDTO> GetAllEvents()
        {
            return Repository.GetAllEvents().ProjectTo<EventDTO>(_mapper.ConfigurationProvider).ToList();
        }

        //Get event by EventId. Map to DTO model
        public EventDTO GetEventById(int id)
        {
            Event e = Repository.GetEventById(id);
            return _mapper.Map<EventDTO>(e);
        }
        
    }
}
