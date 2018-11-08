using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarMeetingManager.DAL;
using CarTuningEventManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarMeetingManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly CarMeetingContext _context;

        public MembersController(CarMeetingContext context)
        {
            _context = context;

            if (_context.Members.Count() == 0)
            {
                List<Member> members = new List<Member>
            {
                new Member {Name="Gert", Surname="Scheers", DateOfBirth=DateTime.Parse("1994-11-17"), Email="gert_378@hotmail.com", CarId=0, ClubId=0}
            };
                members.ForEach(m => context.Members.Add(m));
                context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<Member>> GetAllMembers()
        {
            //Work with includes for complete lists! Cars / types / ...
            return _context.Members.ToList();
        }

        [HttpGet("{id}", Name = "GetMember")]
        public ActionResult<Member> GetById(int id)
        {
            var item = _context.Members.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create([FromBody]Member member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int memberid = _context.Members.Count() + 1;

            _context.Members.Add(member);
            _context.SaveChanges();

            return CreatedAtRoute("GetMember", new { id = memberid }, member);
        }
        
    }
}