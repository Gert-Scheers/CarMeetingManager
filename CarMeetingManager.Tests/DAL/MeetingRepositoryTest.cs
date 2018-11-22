using CarMeetingManager.DAL;
using CarMeetingManager.Models;
using CarMeetingManager.Models.Factory;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CarMeetingManager.Tests.DAL
{
    public class MeetingRepositoryTest
    {
        Mock interfacemock;

        #region Registration
        [Fact]
        public void ShouldCountNumberOfRegistrationsForEventId()
        {
            //Arrange
            IQueryable<Registration> registrations = new List<Registration>
            {
                new Registration
                {
                     EventId = 1,
                     MemberId = 1
                },
                new Registration
                {
                    EventId = 2,
                    MemberId = 1
                },
                new Registration
                {
                     EventId = 2,
                     MemberId = 1
                },
                new Registration
                {
                    EventId = 1,
                    MemberId = 1
                }
            }
            .AsQueryable();

            var mockset = new Mock<DbSet<Registration>>();
            mockset.As<IQueryable<Registration>>().Setup(m => m.Provider).Returns(registrations.Provider);
            mockset.As<IQueryable<Registration>>().Setup(m => m.Expression).Returns(registrations.Expression);
            mockset.As<IQueryable<Registration>>().Setup(m => m.ElementType).Returns(registrations.ElementType);
            mockset.As<IQueryable<Registration>>().Setup(m => m.GetEnumerator()).Returns(registrations.GetEnumerator());

            var mockContext = new Mock<CarMeetingContext>();
            mockContext.Setup(c => c.Registrations).Returns(mockset.Object);

            //Act
            var repository = new MeetingRepository(mockContext.Object);
            var actual = repository.GetNumberOfRegistrationsByEventID(2);

            //Assert
            Assert.Equal(2, actual);
        }
        #endregion

        #region Member

        [Fact]
        public void ShouldReturnAllMembersByClubID()
        {
            //Arrange
            IQueryable<Member> members = new List<Member>
            {
                new Member
                {
         Name="Gert",
         Surname = "Scheers",
         ClubId = 1
                },
                new Member
                {
         Name="Bjorn",
         Surname = "Scheers",
         ClubId = 1
                },
                new Member
                {
         Name="Gert",
         Surname = "Hesp",
         ClubId = 1
                },
                new Member
                {
         Name="Gert",
         Surname = "Kaas",
         ClubId = 2
                }
            }
            .AsQueryable();

            var mockset = new Mock<DbSet<Member>>();
            mockset.As<IQueryable<Member>>().Setup(m => m.Provider).Returns(members.Provider);
            mockset.As<IQueryable<Member>>().Setup(m => m.Expression).Returns(members.Expression);
            mockset.As<IQueryable<Member>>().Setup(m => m.ElementType).Returns(members.ElementType);
            mockset.As<IQueryable<Member>>().Setup(m => m.GetEnumerator()).Returns(members.GetEnumerator());

            var mockContext = new Mock<CarMeetingContext>();
            mockContext.Setup(c => c.Members).Returns(mockset.Object);

            //Act
            var repository = new MeetingRepository(mockContext.Object);
            var actual = repository.GetMembersByClubId(1);

            //Assert
            Assert.Equal(members.Count(x => x.ClubId==1), actual.Count());
        }

        [Fact]
        public void ShouldAddMember()
        {
            // Arrange
            IQueryable<Member> members = new List<Member>().AsQueryable();

            var mockset = new Mock<DbSet<Member>>();
            mockset.As<IQueryable<Member>>().Setup(m => m.Provider).Returns(members.Provider);
            mockset.As<IQueryable<Member>>().Setup(m => m.Expression).Returns(members.Expression);
            mockset.As<IQueryable<Member>>().Setup(m => m.ElementType).Returns(members.ElementType);
            mockset.As<IQueryable<Member>>().Setup(m => m.GetEnumerator()).Returns(members.GetEnumerator());

            var mockContext = new Mock<CarMeetingContext>();
            mockContext.Setup(c => c.Members).Returns(mockset.Object);

            //Act
            var repository = new MeetingRepository(mockContext.Object);
            var actual = repository.AddLid(new Member { Name = "Scheers", Surname = "Kaas", City = "Dorp" });

            //Assert
            mockset.Verify(m => m.Add(It.IsAny<Member>()), Times.Once);
        }

        [Fact]
        public void ShouldReturnMemberByUsername()
        {
            // Arrange
            IQueryable<Member> members = new List<Member>()
            {
                new Member
                {
                    Username="berend"
                },
                new Member
                {
                    Username="Wally"
                }
            }
            .AsQueryable();

            var mockset = new Mock<DbSet<Member>>();
            mockset.As<IQueryable<Member>>().Setup(m => m.Provider).Returns(members.Provider);
            mockset.As<IQueryable<Member>>().Setup(m => m.Expression).Returns(members.Expression);
            mockset.As<IQueryable<Member>>().Setup(m => m.ElementType).Returns(members.ElementType);
            mockset.As<IQueryable<Member>>().Setup(m => m.GetEnumerator()).Returns(members.GetEnumerator());

            var mockContext = new Mock<CarMeetingContext>();
            mockContext.Setup(c => c.Members).Returns(mockset.Object);

            //Act
            var repository = new MeetingRepository(mockContext.Object);
            var actual = repository.GetMemberByUsername("berend");

            //Assert
            Assert.Same(members.SingleOrDefault(x => x.Username == "berend"), actual);
        }

        [Fact]
        public void ShouldRemoveMember()
        {
            // Arrange
            IQueryable<Member> members = new List<Member>()
            {
                new Member
                {
                    Name="Scheers"
                },
                new Member
                {
                    Name="Kaasbal"
                },
                new Member
                {
                    Name="Vervoort"
                }
            }.AsQueryable();

            var mockset = new Mock<DbSet<Member>>();
            mockset.As<IQueryable<Member>>().Setup(m => m.Provider).Returns(members.Provider);
            mockset.As<IQueryable<Member>>().Setup(m => m.Expression).Returns(members.Expression);
            mockset.As<IQueryable<Member>>().Setup(m => m.ElementType).Returns(members.ElementType);
            mockset.As<IQueryable<Member>>().Setup(m => m.GetEnumerator()).Returns(members.GetEnumerator());

            var mockContext = new Mock<CarMeetingContext>();
            mockContext.Setup(c => c.Members).Returns(mockset.Object);

            //Act
            var repository = new MeetingRepository(mockContext.Object);
            var actual = repository.RemoveLid(members.ElementAt(2));

            //Assert
            mockset.Verify(m => m.Remove(It.IsAny<Member>()), Times.Once);
        }

        #endregion

        #region Club
        [Fact]
        public void ShouldAddClub()
        {
            // Arrange
            IQueryable<Club> clubs = new List<Club>().AsQueryable();

            var mockset = new Mock<DbSet<Club>>();
            mockset.As<IQueryable<Club>>().Setup(m => m.Provider).Returns(clubs.Provider);
            mockset.As<IQueryable<Club>>().Setup(m => m.Expression).Returns(clubs.Expression);
            mockset.As<IQueryable<Club>>().Setup(m => m.ElementType).Returns(clubs.ElementType);
            mockset.As<IQueryable<Club>>().Setup(m => m.GetEnumerator()).Returns(clubs.GetEnumerator());

            var mockContext = new Mock<CarMeetingContext>();
            mockContext.Setup(c => c.Clubs).Returns(mockset.Object);

            //Act
            var repository = new MeetingRepository(mockContext.Object);
            var actual = repository.AddClub(new Club { Name = "Testclub", Contact = "niemand", Photo = "no photo", Description = "lala" });
            
            //Assert
            mockset.Verify(m => m.Add(It.IsAny<Club>()), Times.Once);
        }

        [Fact]
        public void ShouldReturnAllClubs()
        {
            IQueryable<Club> clubs = new List<Club>
            {
                new Club
                {
                    Name="1"
                },
                new Club
                {
                    Name="2"
                },
                new Club
                {
                    Name="3"
                }
            }.AsQueryable();

            var mockset = new Mock<DbSet<Club>>();
            mockset.As<IQueryable<Club>>().Setup(m => m.Provider).Returns(clubs.Provider);
            mockset.As<IQueryable<Club>>().Setup(m => m.Expression).Returns(clubs.Expression);
            mockset.As<IQueryable<Club>>().Setup(m => m.ElementType).Returns(clubs.ElementType);
            mockset.As<IQueryable<Club>>().Setup(m => m.GetEnumerator()).Returns(clubs.GetEnumerator());

            var mockContext = new Mock<CarMeetingContext>();
            mockContext.Setup(c => c.Clubs).Returns(mockset.Object);

            //Act
            var repository = new MeetingRepository(mockContext.Object);
            var actual = repository.GetAllClubs();

            //Assert
            Assert.Equal(clubs.Count(), actual.Count());
        }

        [Fact]
        public void ShouldReturnClubById()
        {
            IQueryable<Club> clubs = new List<Club>
            {
                new Club
                {
                    ClubId=1,
                    Name="1"
                },
                new Club
                {
                    ClubId=2,
                    Name="2"
                },
                new Club
                {
                    ClubId=3,
                    Name="3"
                }
            }.AsQueryable();

            var mockset = new Mock<DbSet<Club>>();
            mockset.As<IQueryable<Club>>().Setup(m => m.Provider).Returns(clubs.Provider);
            mockset.As<IQueryable<Club>>().Setup(m => m.Expression).Returns(clubs.Expression);
            mockset.As<IQueryable<Club>>().Setup(m => m.ElementType).Returns(clubs.ElementType);
            mockset.As<IQueryable<Club>>().Setup(m => m.GetEnumerator()).Returns(clubs.GetEnumerator());

            var mockContext = new Mock<CarMeetingContext>();
            mockContext.Setup(c => c.Clubs).Returns(mockset.Object);

            //Act
            var repository = new MeetingRepository(mockContext.Object);
            var actual = repository.GetClubById(2);

            //Assert
            Assert.Same(clubs.ElementAt(1), actual);
        }

        [Fact]
        public void ShouldRemoveclub()
        {
            // Arrange
            IQueryable<Club> clubs = new List<Club>()
            {
                new Club
                {
                    Name="Scheers"
                },
                new Club
                {
                    Name="Kaasbal"
                },
                new Club
                {
                    Name="Vervoort"
                }
            }.AsQueryable();

            var mockset = new Mock<DbSet<Club>>();
            mockset.As<IQueryable<Club>>().Setup(m => m.Provider).Returns(clubs.Provider);
            mockset.As<IQueryable<Club>>().Setup(m => m.Expression).Returns(clubs.Expression);
            mockset.As<IQueryable<Club>>().Setup(m => m.ElementType).Returns(clubs.ElementType);
            mockset.As<IQueryable<Club>>().Setup(m => m.GetEnumerator()).Returns(clubs.GetEnumerator());

            var mockContext = new Mock<CarMeetingContext>();
            mockContext.Setup(c => c.Clubs).Returns(mockset.Object);

            //Act
            var repository = new MeetingRepository(mockContext.Object);
            var actual = repository.RemoveClub(clubs.ElementAt(2));

            //Assert
            mockset.Verify(m => m.Remove(It.IsAny<Club>()), Times.Once);
        }

        [Fact]
        public void ShouldUpdateClub()
        {
            // Arrange
            IQueryable<Club> clubs = new List<Club>()
            {
                new Club
                {
                    ClubId=1,
                    Name="Scheers"
                },
                new Club
                {
                    ClubId=2,
                    Name="Kaasbal"
                },
                new Club
                {
                    ClubId=3,
                    Name="Vervoort"
                }
            }.AsQueryable();

            var mockset = new Mock<DbSet<Club>>();
            mockset.As<IQueryable<Club>>().Setup(m => m.Provider).Returns(clubs.Provider);
            mockset.As<IQueryable<Club>>().Setup(m => m.Expression).Returns(clubs.Expression);
            mockset.As<IQueryable<Club>>().Setup(m => m.ElementType).Returns(clubs.ElementType);
            mockset.As<IQueryable<Club>>().Setup(m => m.GetEnumerator()).Returns(clubs.GetEnumerator());

            var mockContext = new Mock<CarMeetingContext>();
            mockContext.Setup(c => c.Clubs).Returns(mockset.Object);

            //Act
            var repository = new MeetingRepository(mockContext.Object);
            Club cl = clubs.ElementAt(1);
            cl.Name = "UpdatedClub";
            var actual = repository.UpdateClub(cl);

            //Assert
            mockset.Verify(m => m.Update(It.IsAny<Club>()), Times.Once);
        }
        #endregion

        #region Event
        [Fact]
        public void ShouldReturnAllEvents()
        {
            IQueryable<Event> events = new List<Event>
            {
                new Event
                {
                     Name="event1"
                },
                new Event
                {
                    Name="event 2"
                },
                new Event
                {
                    Name="event 3"
                }
            }.AsQueryable();

            var mockset = new Mock<DbSet<Event>>();
            mockset.As<IQueryable<Event>>().Setup(m => m.Provider).Returns(events.Provider);
            mockset.As<IQueryable<Event>>().Setup(m => m.Expression).Returns(events.Expression);
            mockset.As<IQueryable<Event>>().Setup(m => m.ElementType).Returns(events.ElementType);
            mockset.As<IQueryable<Event>>().Setup(m => m.GetEnumerator()).Returns(events.GetEnumerator());

            var mockContext = new Mock<CarMeetingContext>();
            mockContext.Setup(c => c.Events).Returns(mockset.Object);

            //Act
            var repository = new MeetingRepository(mockContext.Object);
            var actual = repository.GetAllEvents();

            //Assert
            Assert.Equal(events.Count(), actual.Count());
        }

        [Fact]
        public void ShouldReturnEventById()
        {
            IQueryable<Event> events = new List<Event>
            {
                new Event
                {
                    EventId=1,
                     Name="event1"
                },
                new Event
                {
                    EventId=2,
                    Name="event 2"
                },
                new Event
                {
                    EventId=3,
                    Name="event 3"
                }
            }.AsQueryable();

            var mockset = new Mock<DbSet<Event>>();
            mockset.As<IQueryable<Event>>().Setup(m => m.Provider).Returns(events.Provider);
            mockset.As<IQueryable<Event>>().Setup(m => m.Expression).Returns(events.Expression);
            mockset.As<IQueryable<Event>>().Setup(m => m.ElementType).Returns(events.ElementType);
            mockset.As<IQueryable<Event>>().Setup(m => m.GetEnumerator()).Returns(events.GetEnumerator());

            var mockContext = new Mock<CarMeetingContext>();
            mockContext.Setup(c => c.Events).Returns(mockset.Object);

            //Act
            var repository = new MeetingRepository(mockContext.Object);
            var actual = repository.GetEventById(2);

            //Assert
            Assert.Same(events.SingleOrDefault(x => x.EventId == 2), actual);
        }
        #endregion

        [Fact]
        public void Init()
        {
            interfacemock = new Mock<IMeetingRepository>();
        }
    }
}
