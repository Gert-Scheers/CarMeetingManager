using CarMeetingManager.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarMeetingManager.BLL.Interfaces
{
    public interface IClubsBL
    {
        List<ClubDTO> GetClubs();
        string AddClub(ClubDTO club);
        ClubDTO GetClubById(int id);
        string RemoveClub(ClubDTO club);
        string UpdateClub(ClubDTO club);

    }
}
