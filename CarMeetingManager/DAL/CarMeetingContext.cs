using CarMeetingManager.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace CarMeetingManager.DAL
{
    public class CarMeetingContext : DbContext
    {
        public CarMeetingContext(DbContextOptions<CarMeetingContext> options) : base(options)
        {

        }
        public CarMeetingContext()
        {

        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Club> Clubs { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        //public DbSet<EventTypes> EventTypes { get; set; }
        public virtual DbSet<CarMake> CarMakes { get; set; }
        //public DbSet<LoweringType> Lowerings { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }
        
    }
}