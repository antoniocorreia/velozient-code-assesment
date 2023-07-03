using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelozientDroneCodeChallenge.Domain.Entities;
using VelozientDroneCodeChallenge.Infrasctructure;

namespace VelozientDroneCodeChallenge.Tests.FileTests
{
    public class OutputWriterTests
    {
        [Fact]
        public void Write_ValidPath_WritesFileWithCorrectContent()
        {
            // Arrange
            string path = "output.txt";

            // Create sample trips
            List<Trip> trips = new List<Trip>
            {
                new Trip(new Drone("DroneA", 30), 1, new List<Location> { new Location("LocationA", 10), new Location("LocationB",20)}),
                new Trip(new Drone("DroneB", 30), 1, new List<Location> { new Location("LocationC", 10), new Location("LocationD",20)}),
                new Trip(new Drone("DroneC", 30), 1, new List<Location> { new Location("LocationE", 10), new Location("LocationF",20)})                
            };

            // Act
            OutputWriter.Write(path, trips);

            // Assert
            string[] fileContent = File.ReadAllLines(path);

            fileContent.Should().HaveCountGreaterThan(9); // 3 trips + 3 drone headers + 3 trip headers
            fileContent[0].Should().Be("[DroneA]");
            fileContent[1].Should().Be("Trip #1");
            fileContent[2].Should().Be("[LocationA], [LocationB]");
            
            // Clean up
            File.Delete(path);
        }
    }
}
