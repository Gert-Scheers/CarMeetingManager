using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarMeetingManager.DAL;
using CarMeetingManager.Models;
using CarMeetingManager.BLL;
using CarMeetingManager.BLL.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using CarMeetingManager.BLL.Interfaces;

namespace CarMeetingManager.Controllers
{
    [EnableCors("Localhost")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClubsController : ControllerBase
    {
        readonly IClubsBL _clubs;

        public ClubsController(IClubsBL clubs)
        {
            _clubs = clubs;
        }
        
        // GET: api/Clubs
        [HttpGet]
        public List<ClubDTO> GetClubs()
        {
            return _clubs.GetClubs();
        }

        // GET: api/Clubs/5
        [HttpGet("{id}")]
        public ClubDTO GetClub([FromRoute] int id)
        {
            /*if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var club = await _context.Clubs.FindAsync(id);

            if (club == null)
            {
                return NotFound();
            }

            return Ok(club);*/
            return _clubs.GetClubById(id);
        }

        // PUT: api/Clubs/5
        [HttpPut("{id}")]
        public string PutClub([FromRoute] int id, [FromBody] ClubDTO club)
        {
            return "";
        }

        // POST: api/Clubs
        [HttpPost]
        public string PostClub([FromBody] ClubDTO club)
        {
            /*if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Clubs.Add(club);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClub", new { id = club.ClubId }, club);*/
            return _clubs.AddClub(club);
        }

        /*// DELETE: api/Clubs/5
        [HttpDelete("{id}")]
        public string DeleteClub([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var club = await _context.Clubs.FindAsync(id);
            if (club == null)
            {
                return NotFound();
            }

            _context.Clubs.Remove(club);
            await _context.SaveChangesAsync();

            return Ok(club);
        }

        private bool ClubExists(int id)
        {
            return _clubs.Clubs.Any(e => e.ClubId == id);
        }*/
    }
}