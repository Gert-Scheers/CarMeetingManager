using CarMeetingManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarMeetingManager.DAL
{
    public interface IMeetingRepository
    {
        //Registrations
        int GetNumberOfRegistrationsByEventID(int id);

        //Members
        IEnumerable<Member> GetMembersByClubId(int id);
        bool AddLid(Member member);
        Car GetWagenByMemberID(int id);
        bool RemoveLid(Member member);

        //Events
        IEnumerable<Event> GetAllEvents();
        Event GetEventById(int id);
        IEnumerable<Event> GetEventsByTypeId(int id);

        //Clubs
        IEnumerable<Club> GetAllClubs();
        Club GetClubById(int id);
        bool AddClub(Club club);
        bool UpdateClub(Club club);
        bool RemoveClub(Club club);
    }
}
