using CarMeetingManager.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarMeetingManager.BLL
{
    public class ClubsBL
    {
        List<ClubDTO> Clubs = new List<ClubDTO>();
        ClubsDA clubsda = new ClubsDA();

        public List<ClubDTO> GetClubs()
        {
            return null;
        }
    }
}
