using CarMeetingManager.Models;
using Microsoft.EntityFrameworkCore;
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
        public DbSet<German> Germans { get; set; }
        public DbSet<Japanese> Japaneses { get; set; }
        public DbSet<Lowering> Lowerings { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Registration> Registrations { get; set; }


        protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Japanese>().HasData(
                new Japanese { Make = "Mazda" },
                new Japanese { Make = "Mitsubishi" },
                new Japanese { Make = "Honda" },
                new Japanese { Make = "Subaru" },
                new Japanese { Make = "Toyota" },
                new Japanese { Make = "Suzuki" },
                new Japanese { Make = "Nissan" },
                new Japanese { Make = "Daihatsu" });

            modelBuilder.Entity<German>().HasData(
                new German { Make = "BMW" },
                new German { Make = "Audi" },
                new German { Make = "Mercedes" },
                new German { Make = "Porsche" },
                new German { Make = "Volkswagen" },
                new German { Make = "Opel" });

            modelBuilder.Entity<Lowering>().HasData(
                new German { Make = "BMW" },
                new German { Make = "Audi" },
                new German { Make = "Mercedes" },
                new German { Make = "Porsche" },
                new German { Make = "Volkswagen" },
                new German { Make = "Opel" });

            modelBuilder.Entity<EventType>().HasData(
                new EventType { Type = "Japans" },
                new EventType { Type = "Duits" },
                new EventType { Type = "Oldtimer" },
                new EventType { Type = "Tuning" },
                new EventType { Type = "Open" });

            modelBuilder.Entity<Event>().HasData(
                new Event { Name = "Japfest", Capacity = 1500, Location = "Zandvoort", EventTypeId = 1,
                    Description = "Meeting op Circuit Zandvoort, enkel voor Japanse auto's en brommers." },
                new Event { Name = "Germanized", Capacity = 500, Location = "Hechtel",
                    Description = "Meeting voor Duitse merken.", EventTypeId = 2 });

            modelBuilder.Entity<Club>().HasData(
                new Club { Name = "MazdaClubBelgium",
                    Description = "Club uit België, alle modellen binnen mazda zijn toegelaten.",
                    Contact = "mazdaclubbe@hotmail.com" },
                new Club { Name = "DuitseOldtimer", Description = "Club voor duitse oldtimers.",
                    Contact = "DuitseOldtimer@hotmail.com" });

            modelBuilder.Entity<Car>().HasData(
                new Car { Make = "Mazda", Model = "3", Displacement = "2000cc",
                    LoweringId = 2, ProductionYear = 2015, Wheels = "19\" ASA TEC GT-7" });

            modelBuilder.Entity<Member>().HasData(
                new Member { Name = "Gert", Surname = "Scheers",
                    DateOfBirth = DateTime.Parse("1994-11-17").Date, Email = "gert_378@hotmail.com", CarId = 1,
                    ClubId = 1, City = "Lommel", PostalCode = "3920", Username = "gert.scheers", Password = "test" });
        }
    }
}
