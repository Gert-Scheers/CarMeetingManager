using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarMeetingManager.DAL
{
    public class RegistrationsDA
    {
        protected CarMeetingContext Context;

        public RegistrationsDA(CarMeetingContext context)
        {
            this.Context = context;
        }

        public int GetNumberOfRegistrationsByEventID(int id)
        {//TODO
            return Context.Registrations.Where(e => e.EventId == id).Count();
        }
    }
}
