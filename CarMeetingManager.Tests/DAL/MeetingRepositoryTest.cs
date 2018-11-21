using CarMeetingManager.DAL;
using CarMeetingManager.Models;
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
        public void ShouldReturnAllMembersByCludID()
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
            Assert.Equal(3, actual.Count());
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
            Assert.Same(members.ElementAt(0), actual);
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
            var actual = repository.RemoveLid(members.ElementAt(1));

            //Assert
            mockset.Verify(m => m.Remove(It.IsAny<Member>()), Times.Once);
        }

        #endregion

        [Fact]
        public void Init()
        {
            interfacemock = new Mock<IMeetingRepository>();
        }
    }
}
