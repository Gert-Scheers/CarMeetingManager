using CarMeetingManager.DAL;
using CarMeetingManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarMeetingManager.Controllers
{
    [Route("api/carmeetingmanager")]
    [ApiController]
    public class CarMeetingManagerController : Controller
    {
        private readonly CarMeetingContext _context;

        public CarMeetingManagerController(CarMeetingContext context)
        {
            _context = context;
            if (!_context.Database.EnsureCreated())
            {
                _context.Database.Migrate();

                var japanese = new List<Japanese>
                    {
                        new Japanese { Make = "Mazda"},
                        new Japanese { Make = "Mitsubishi"},
                        new Japanese { Make = "Honda"},
                        new Japanese { Make = "Subaru"},
                        new Japanese { Make = "Toyota"},
                        new Japanese { Make = "Suzuki"},
                        new Japanese { Make = "Nissan"},
                        new Japanese { Make = "Daihatsu"}
                    };
                japanese.ForEach(j => _context.Japaneses.Add(j));
                _context.SaveChanges();

                var german = new List<German>
                    {
                        new German { Make="BMW" },
                        new German { Make="Audi" },
                        new German { Make="Mercedes" },
                        new German { Make="Porsche" },
                        new German { Make="Volkswagen"},
                        new German { Make="Opel"}
                    };
                german.ForEach(g => _context.Germans.Add(g));
                _context.SaveChanges();

                var lowerings = new List<Lowering>()
                    {
                        new Lowering { Type = "None" },
                        new Lowering { Type = "Veren" },
                        new Lowering { Type = "Schroefset" },
                        new Lowering { Type = "Air Ride"}
                    };
                lowerings.ForEach(l => _context.Lowerings.Add(l));
                _context.SaveChanges();

                var eventtypes = new List<EventType>()
                    {
                        new EventType { Type = "Japans" },
                        new EventType { Type = "Duits" },
                        new EventType { Type = "Oldtimer" },
                        new EventType { Type = "Tuning"},
                        new EventType { Type = "Open"}
                    };
                eventtypes.ForEach(l => _context.EventTypes.Add(l));
                _context.SaveChanges();

                var events = new List<Event>
                    {
                        new Event { Name="Japfest", Capacity=1500, Location="Zandvoort", EventTypeId=1, Description="Meeting op Circuit Zandvoort, enkel voor Japanse auto's en brommers." },
                        new Event { Name="Germanized", Capacity = 500, Location="Hechtel", Description="Meeting voor Duitse merken.", EventTypeId=2}
                    };
                events.ForEach(e => _context.Events.Add(e));
                _context.SaveChanges();

                var clubs = new List<Club>
                    {
                        new Club{ Name="MazdaClubBelgium", Description="Club uit België, alle modellen binnen mazda zijn toegelaten.", Contact="mazdaclubbe@hotmail.com"},
                        new Club { Name="DuitseOldtimer", Description="Club voor duitse oldtimers.", Contact="DuitseOldtimer@hotmail.com"}
                    };
                clubs.ForEach(c => _context.Clubs.Add(c));
                _context.SaveChanges();

                var cars = new List<Car>
                    {
                        new Car{ Make = "Mazda", Model ="3", Displacement="2000cc", LoweringId=2, ProductionYear=2015, Wheels="19\" ASA TEC GT-7"}
                    };
                cars.ForEach(c => context.Cars.Add(c));
                context.SaveChanges();

                List<Member> members = new List<Member>
                    {
                        new Member {Name="Gert", Surname="Scheers", DateOfBirth=DateTime.Parse("1994-11-17"), Email="gert_378@hotmail.com", CarId=1, ClubId=1, City="Lommel", PostalCode="3920", Username="gert.scheers", Password="test" }
                    };
                members.ForEach(m => _context.Members.Add(m));
                _context.SaveChanges();
            }
        }

        // GET: api/Cars
        [HttpGet]
        public IEnumerable<Car> GetCars()
        {
            return _context.Cars;
        }
    }
}
