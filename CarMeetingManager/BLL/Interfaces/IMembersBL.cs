using CarMeetingManager.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarMeetingManager.BLL.Interfaces
{
    public interface IMembersBL
    {
        bool AddLid(MemberDTO member);
        bool RemoveLid(MemberDTO member);
        List<MemberDTO> GetMembersByClubId(int id);
        MemberDTO GetMemberByUsername(string username);
    }
}
