using CarMeetingManager.DAL;
using CarMeetingManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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