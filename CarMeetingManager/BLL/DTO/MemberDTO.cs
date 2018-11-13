using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarMeetingManager.BLL.DTO
{
    public class MemberDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int CarId { get; set; }
        public int ClubId { get; set; }

        //public Car Car { get; set; }
        //public Club Club { get; set; }
    }
}
