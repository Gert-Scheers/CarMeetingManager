using CarMeetingManager.BLL.DTO;
using CarMeetingManager.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarMeetingManager.BLL
{
    public class RegistrationsBL
    {
        private readonly CarMeetingContext _context;
        List<RegistrationDTO> Events = new List<RegistrationDTO>();
        IMeetingRepository Repository;

        public RegistrationsBL(CarMeetingContext context)
        {
            _context = context;
            Repository = new MeetingRepository(context);
        }

        //Get number of registrations from DAL
        public int GetNumberOfRegistrationsByEventID(int id)
        {
            return Repository.GetNumberOfRegistrationsByEventID(id);
        }
    }
}
