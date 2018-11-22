using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarMeetingManager.Models.Factory
{
    public static class MemberFactory
    {
        public static Member CreateMember()
        {
            return new Member();
        }
    }
}
