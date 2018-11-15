using AutoMapper;
using CarMeetingManager.BLL.DTO;
using CarMeetingManager.DAL;
using CarMeetingManager.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarMeetingManager.BLL
{
    public class ClubsBL
    {
        private CarMeetingContext _context;
        List<ClubDTO> Clubs = new List<ClubDTO>();
        StringBuilder message = new StringBuilder();
        IMeetingRepository Repository;

        public ClubsBL(CarMeetingContext context)
        {
            _context = context;
            Repository = new MeetingRepository(context);
        }

        public IEnumerable<ClubDTO> GetClubs()
        {
            List<Club> list = Repository.GetAllClubs().ToList();
            foreach (var item in list)
            {
                ClubDTO club = Mapper.Map<ClubDTO>(item);
                Clubs.Add(club);
            }
            return Clubs;
        }

        public string AddClub(ClubDTO club)
        {
            Clubs = GetClubs().ToList();

            foreach (ClubDTO item in Clubs)
            {
                if (item.Name == club.Name)
                {
                    message.Append("There's already an existing club with that name.");
                    return message.ToString();
                }
            }
            Club c = Mapper.Map<Club>(club);
            if (c.Photo is null || c.Photo =="")
            {
                c.Photo = "No photo";
            }

            if (Repository.AddClub(c))
            {
                message.Append("Club has been created!");
            }
            else
            {
                //TODO: Message exception
                message.Append("Something went wrong.");
            }
            return message.ToString();
        }

        public ClubDTO GetClubById(int id)
        {
            Club c = Repository.GetClubById(id);
            return Mapper.Map<ClubDTO>(c);
        }

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
