using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarMeetingManager.Models;

namespace CarMeetingManager.DAL
{
    public class MeetingRepository : IMeetingRepository
    {
        private CarMeetingContext _context;

        public MeetingRepository (CarMeetingContext context)
        {
            _context = context;
        }

        #region Registration
        //Registrations
        public int GetNumberOfRegistrationsByEventID(int id)
        {
            return _context.Registrations.Where(r => r.EventId == id).Count();
        }
        #endregion

        #region Member
        public bool AddLid(Member member)
        {
            _context.Members.Add(member);
            _context.SaveChanges();
            return true;
        }

        public bool RemoveLid(Member member)
        {
            _context.Members.Remove(member);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Member> GetMembersByClubId(int id)
        {
            return _context.Members.Where(m => m.ClubId == id).AsEnumerable();
        }

        public Car GetWagenByMemberID(int id)
        {
            return _context.Cars.Where(c => c.MemberId == id).SingleOrDefault();
        }

        public Member GetMemberByUsername(string username)
        {
            return _context.Members.SingleOrDefault(u => u.Username == username);
        }

        #endregion

        #region Clubs
        public bool AddClub(Club club)
        {
            _context.Clubs.Add(club);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Club> GetAllClubs()
        {
            return _context.Clubs.AsEnumerable();
        }

        public Club GetClubById(int id)
        {
            return _context.Clubs.Where(c => c.ClubId == id).SingleOrDefault();
        }

        public bool RemoveClub(Club club)
        {
            _context.Clubs.Remove(club);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateClub(Club club)
        {
            _context.Clubs.Update(club);
            _context.SaveChanges();
            return true;
        }
        #endregion

        #region Events
        public IEnumerable<Event> GetAllEvents()
        {
            return _context.Events.AsEnumerable();
        }

        public Event GetEventById(int id)
        {
            return _context.Events.Where(e => e.EventId == id).SingleOrDefault();
        }
        #endregion
    }
}
