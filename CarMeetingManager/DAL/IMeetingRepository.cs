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
        IQueryable<Member> GetMembersByClubId(int id);
        bool AddLid(Member member);
        Car GetWagenByMemberID(int id);
        bool RemoveLid(Member member);
        Member GetMemberByUsername(string username);

        //Events
        IQueryable<Event> GetAllEvents();
        Event GetEventById(int id);

        //Clubs
        IQueryable<Club> GetAllClubs();
        Club GetClubById(int id);
        bool AddClub(Club club);
        bool UpdateClub(Club club);
        bool RemoveClub(Club club);
    }
}
