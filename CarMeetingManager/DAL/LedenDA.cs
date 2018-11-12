using CarMeetingManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarMeetingManager.DAL
{
    public class LedenDA
    {
        protected CarMeetingContext Context { get; set; }

        public LedenDA(CarMeetingContext context)
        {
            this.Context = context;
        }

        public List<Member> GetMembersByClubId(int id)
        {
            return Context.Members.Where(m => m.ClubId == id).ToList();
        }

        public bool AddLid(Member member)
        {
            if (Context.Members.Where(m => m.Username == member.Username || m.Email == member.Email).Count() == 0)
            {
                Context.Members.Add(member);
                Context.SaveChanges();
                return true;
            }
            return false;
        }

        public Car GetWagenByMemberID(int id)
        {
            return Context.Cars.Where(c => c.MemberId == id).SingleOrDefault();
        }

        public bool RemoveLid(Member member)
        {
            if (member != null)
            {
                Context.Members.Remove(member);
                Context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
