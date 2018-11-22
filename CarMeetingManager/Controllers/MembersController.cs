using CarMeetingManager.BLL.Interfaces;
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
        readonly IMembersBL _members;

        public MembersController(IMembersBL mem)
        {
            _members = mem;
        }

        [HttpGet]
        public ActionResult<List<Member>> GetAllMembers()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}", Name = "GetMember")]
        public ActionResult<Member> GetById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Create([FromBody]Member member)
        {
            throw new NotImplementedException();
        }

    }
}