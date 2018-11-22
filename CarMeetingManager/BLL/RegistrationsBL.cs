using CarMeetingManager.BLL.DTO;
using CarMeetingManager.BLL.Interfaces;
using CarMeetingManager.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarMeetingManager.BLL
{
    public class RegistrationsBL : IRegistrationsBL
    {
        List<RegistrationDTO> Events = new List<RegistrationDTO>();
        IMeetingRepository Repository;

        public RegistrationsBL(IMeetingRepository repo)
        {
            Repository = repo;
        }

        //Get number of registrations from DAL
        public int GetNumberOfRegistrationsByEventID(int id)
        {
            return Repository.GetNumberOfRegistrationsByEventID(id);
        }
    }
}
