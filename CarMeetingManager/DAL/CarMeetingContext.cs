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

        public DbSet<Car> Cars { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<CarMake> CarMakes { get; set; }
        public DbSet<Lowering> Lowerings { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        
    }
}