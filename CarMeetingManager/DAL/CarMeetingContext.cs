using CarTuningEventManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public DbSet<German> Germans { get; set; }
        public DbSet<Japanese> Japaneses { get; set; }
        public DbSet<Lowering> Lowerings { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Registration> Registrations { get; set; }
    }
}
