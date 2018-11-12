using CarMeetingManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarMeetingManager.DAL
{
    public class ClubsDA
    {
        protected CarMeetingContext Context { get; set; }

        public ClubsDA(CarMeetingContext context)
        {
            this.Context = context;
        }

        public List<Club> GetAllClubs()
        {
            return Context.Clubs.ToList();
        }

        public Club GetClubById(int id)
        {
            if (id != 0)
            {
                return Context.Clubs.Where(c => c.ClubId == id).SingleOrDefault();
            }
            return null;
        }

        public bool AddClub(Club club)
        {
            if (Context.Clubs.Where(c => c.Name == club.Name).Count() == 0)
            {
                Context.Clubs.Add(club);
                Context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateClub(Club club)
        {
            if (club != null)
            {
                Context.Clubs.Update(club);
                Context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool RemoveClub(Club club)
        {
            if (club != null)
            {
                Context.Clubs.Remove(club);
                Context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}