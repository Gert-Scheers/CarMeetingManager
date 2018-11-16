using AutoMapper;
using CarMeetingManager.BLL.DTO;
using CarMeetingManager.DAL;
using CarMeetingManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarMeetingManager.BLL
{
    public class MembersBL
    {
        private CarMeetingContext _context;
        List<MemberDTO> Events = new List<MemberDTO>();
        IMeetingRepository Repository;

        public MembersBL(CarMeetingContext context)
        {
            _context = context;
            Repository = new MeetingRepository(context);
        }

        public MemberDTO GetMemberByUsername(string username)
        {
            Member m = Repository.GetMemberByUsername(username);
            return Mapper.Map<MemberDTO>(m);
        }
    }
}
