using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelozientDroneCodeChallenge.Application.Model;
using VelozientDroneCodeChallenge.Domain.Entities;
using VelozientDroneCodeChallenge.Infrasctructure.Services;

namespace VelozientDroneCodeChallenge.Tests.ServiceTests
{
    public class DeliverySchedulerTests
    {
        [Fact]
        public void Execute_ValidInput_ReturnsListOfTrips()
        {
            // Arrange
            var scheduler = new DeliveryScheduler();
            var drones = new List<Drone>
            {
                new Drone("DroneA", 200),
                new Drone("DroneB", 250),
                new Drone("DroneC", 100)
            };
            var locations = new List<Location>
            {
                new Location("LocationA", 200),
                new Location("LocationB", 150),
                new Location("LocationC", 50),
                new Location("LocationD", 150)
            };
            var fileResult = new FileResult(drones, locations);

            // Act
            var result = scheduler.Execute(fileResult);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(4);

            var trips = result.ToList();
            trips[0].Drone.Name.Should().Be("DroneB");
            trips[0].Code.Should().Be(1);
            trips[0].Locations.Should().HaveCount(2);

            trips[1].Drone.Name.Should().Be("DroneA");
            trips[1].Code.Should().Be(1);
            trips[1].Locations.Should().HaveCount(1);

            trips[2].Drone.Name.Should().Be("DroneC");
            trips[2].Locations.Should().HaveCount(0);

            trips[3].Drone.Name.Should().Be("DroneB");
            trips[3].Code.Should().Be(2);
            trips[3].Locations.Should().HaveCount(1);
        }
    }
}
