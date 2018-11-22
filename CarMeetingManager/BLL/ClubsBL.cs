using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarMeetingManager.BLL.DTO;
using CarMeetingManager.BLL.Interfaces;
using CarMeetingManager.DAL;
using CarMeetingManager.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarMeetingManager.BLL
{
    public class ClubsBL : IClubsBL
    {
        List<ClubDTO> Clubs = new List<ClubDTO>();
        StringBuilder message = new StringBuilder();
        IMeetingRepository Repository;
        IMapper _mapper;

        public ClubsBL(IMeetingRepository repo, IMapper mapper)
        {
            Repository = repo;
            _mapper = mapper;
        }

        //Ask clubs from DAL & map them to DTO format
        public List<ClubDTO> GetClubs()
        {
            List<ClubDTO> list = Repository.GetAllClubs().ProjectTo<ClubDTO>(_mapper.ConfigurationProvider).ToList();
            if (!list.Any())
            {
                throw new System.Exception("No clubs found.");
            }
            foreach (var item in list)
            {
                ClubDTO club = _mapper.Map<ClubDTO>(item);
                Clubs.Add(club);
            }
            return Clubs;
        }

        //Ask DAL to Add club
        public string AddClub(ClubDTO club)
        {
            //Get list of current existing clubs
            Clubs = GetClubs();

            //Check if there's any club with given name
            foreach (ClubDTO item in Clubs)
            {
                if (item.Name == club.Name)
                {
                    message.Append("There's already an existing club with that name.");
                    return message.ToString();
                }
            }

            //If club doesn't exist yet, set default value to photo if not added.
            Club c = Mapper.Map<Club>(club);
            if (c.Photo is null || c.Photo == "")
            {
                c.Photo = "No photo";
            }

            if (Repository.AddClub(c))
            {
                message.Append("Club has been created!");
            }
            else
            {
                message.Append("Something went wrong.");
            }
            return message.ToString();
        }

        //Get club by clubId from DAL, map to DTO model
        public ClubDTO GetClubById(int id)
        {
            Club c = Repository.GetClubById(id);
            return _mapper.Map<ClubDTO>(c);
        }

        //Remove given club
        public string RemoveClub(ClubDTO club)
        {
            Club c = Mapper.Map<Club>(club);
            if (Repository.RemoveClub(c))
            {
                message.Append("Club has succesfully been removed!");
            }
            else
            {
                //TODO Message exception
                message.Append("Something went wrong.");
            }
            return message.ToString();
        }

        //update given club
        public string UpdateClub(ClubDTO club)
        {
            Club c = Mapper.Map<Club>(club);
            if (Repository.UpdateClub(c))
            {
                message.Append("Club has succesfully been updated!");
            }
            else
            {
                //TODO Message exception
                message.Append("Something went wrong.");
            }
            return message.ToString();
        }
    }
}
