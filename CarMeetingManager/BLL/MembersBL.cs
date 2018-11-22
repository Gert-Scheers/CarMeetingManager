using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarMeetingManager.BLL.DTO;
using CarMeetingManager.BLL.Interfaces;
using CarMeetingManager.DAL;
using CarMeetingManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarMeetingManager.BLL
{
    public class MembersBL : IMembersBL
    {
        List<MemberDTO> Members = new List<MemberDTO>();
        IMeetingRepository Repository;
        IMapper _mapper;

        public MembersBL(IMeetingRepository repo, IMapper mapper)
        {
            Repository = repo;
            _mapper = mapper;
        }

        //Get member by username. Return DTO model
        public MemberDTO GetMemberByUsername(string username)
        {
            Member m = Repository.GetMemberByUsername(username);
            if (m == null)
            {
                return null;
            }
            return _mapper.Map<MemberDTO>(m);
        }

        public bool AddLid(MemberDTO member)
        {
            throw new NotImplementedException();
        }

        public List<MemberDTO> GetMembersByClubId(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveLid(MemberDTO member)
        {
            throw new NotImplementedException();
        }
    }
}
