using H6_API.Application.Services;
using H6_API.Domain.Entites;
using H6_API.Domain.Interfaces.Repositories;
using FluentAssertions;
using Microsoft.Identity.Client;
using Moq;

namespace H6_API.Tests
{
    public class TrackedMediaServiceTests
    {
        TrackedMediaService service;
        Mock<IUnitOfWork> _UnitofWorkMock = new Mock<IUnitOfWork> ();

        public TrackedMediaServiceTests()
        {
            service = new TrackedMediaService(_UnitofWorkMock.Object);
        }

        [Fact]
        public async void GetAllByUserIdAsync_ShouldReturnTrackedMedia_WhenUserExists()
        {
            //Arrange
            var userId = Guid.NewGuid().ToString();
            var trackedMediaDto = new List<TrackedMedia>
            {
                new TrackedMedia
                {
                    Id = 1,
                    TrackedState = TrackedState.PlanToWatch,
                    ApplicationUser = new ApplicationUser {
                         Id = userId
                    },
                    ImdbId = "TestIMDBId"
                    
                }

            };
            _UnitofWorkMock.Setup(x => x.TrackedMediaRepository.GetAllByUserIdAsync(userId)).ReturnsAsync(trackedMediaDto);
            //Act
            var trackedMedia = await service.GetAllByUserIdAsync(userId);
            //Assert
            trackedMedia.Should().NotBeNull().And.HaveCount(1);

            trackedMedia[0].Should().BeEquivalentTo(trackedMediaDto[0],
                options => options.ExcludingMissingMembers());
        }
    }
}