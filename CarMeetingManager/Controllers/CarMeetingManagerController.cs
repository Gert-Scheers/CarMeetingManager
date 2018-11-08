using CarMeetingManager.DAL;
using CarTuningEventManager.Models;
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

            if (_context.Lowerings.Count() == 0)
            {
                var lowerings = new List<Lowering>()
            {
                new Lowering { Type = "None" },
                new Lowering { Type = "Veren" },
                new Lowering { Type = "Schroefset" },
                new Lowering { Type = "Air Ride"}
            };
                lowerings.ForEach(l => context.Lowerings.Add(l));
                context.SaveChanges();

                var members = new List<Member>
            {
                new Member {Name="Gert", Surname="Scheers", DateOfBirth=DateTime.Parse("1994-11-17"), Email="gert_378@hotmail.com", CarId=0, ClubId=0}
            };
                members.ForEach(m => context.Members.Add(m));
                context.SaveChanges();

                var cars = new List<Car>
            {
                new Car{ Make = "Mazda", Model ="3", Displacement="2000cc", LoweringId=2, ProductionYear=2015, Wheels="19\" ASA TEC GT-7"}
            };
                cars.ForEach(c => context.Cars.Add(c));
                context.SaveChanges();

                var japanese = new List<Japanese>
            {
                new Japanese { Make = "Mazda"},
                new Japanese { Make = "Mitsubishi"},
                new Japanese { Make = "Honda"},
                new Japanese { Make = "Subaru"},
                new Japanese { Make = "Toyota"},
                new Japanese { Make = "Suzuki"},
                new Japanese { Make = "Nissan"},
                new Japanese { Make = "Daihatsu"},
            };
                japanese.ForEach(j => context.Japaneses.Add(j));
                context.SaveChanges();

                var german = new List<German>
            {
                new German { Make="BMW" },
                new German { Make="Audi" },
                new German { Make="Mercedes" },
                new German { Make="Porsche" },
                new German { Make="Volkswagen"},
                new German { Make="Opel"}
            };
                german.ForEach(g => context.Germans.Add(g));
                context.SaveChanges();

                var eventTypes = new List<EventType>
            {
                new EventType{ Type="Japans"},
                new EventType { Type="Duits"},
                new EventType { Type="Oldtimer"},
                new EventType{Type="Tuning"},
                new EventType {Type="Open" }
            };
                eventTypes.ForEach(e => context.EventTypes.Add(e));
                context.SaveChanges();

                var clubs = new List<Club>
            {
                new Club{ Name="MazdaClubBelgium", Description="Club uit België, alle modellen binnen mazda zijn toegelaten.", Contact="mazdaclubbe@hotmail.com"},
                new Club { Name="DuitseOldtimer", Description="Club voor duitse oldtimers.", Contact="DuitseOldtimer@hotmail.com"}
            };
                clubs.ForEach(c => context.Clubs.Add(c));
                context.SaveChanges();
            }
        }

        /*[HttpGet]
        public ActionResult<List<Member>> GetAllMembers()
        {
            //Work with includes for complete lists! Cars / types / ...
            return _context.Members.ToList();
        }*/

        [HttpGet]
        public ActionResult<List<Lowering>> GetAllLowerings()
        {
            return _context.Lowerings.ToList();
        }
    }
}
