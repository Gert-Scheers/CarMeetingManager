using CarMeetingManager.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarMeetingManager.BLL.Interfaces
{
    public interface IEventsBL
    {
        List<EventDTO> GetAllEvents();
        EventDTO GetEventById(int id);
    }
}
