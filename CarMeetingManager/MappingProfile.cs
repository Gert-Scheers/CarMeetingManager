using AutoMapper;
using CarMeetingManager.BLL.DTO;
using CarMeetingManager.Models;

namespace CarMeetingManager
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Club, ClubDTO>();
            CreateMap<ClubDTO, Club>();
            CreateMap<Event, EventDTO>();
            CreateMap<EventDTO, Event>();
            CreateMap<Member, MemberDTO>();
            CreateMap<MemberDTO, Member>();
            CreateMap<Registration, RegistrationDTO>();
            CreateMap<RegistrationDTO, Registration>();
            CreateMap<CarDTO, Car>();
            CreateMap<Car, CarDTO>();
        }
    }
}
