using FluentAssertions;
using VelozientDroneCodeChallenge.Application.Exceptions;
using VelozientDroneCodeChallenge.Domain.Entities;
using VelozientDroneCodeChallenge.Infrasctructure.Parser;

namespace VelozientDroneCodeChallenge.Tests.ParseTests
{
    public class DroneParserTests
    {
        [Fact]
        public void Parse_ValidLines_ReturnsListOfDrones()
        {
            // Arrange
            var parser = new DroneParser();
            var lines = new List<string> { "[DroneA], [200], [DroneB], [250], [DroneC], [100]" };

            // Act
            var result = parser.Parse<Drone>(lines);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(3);

            var drones = result.ToList();
            drones[0].Name.Should().Be("DroneA");
            drones[0].MaximumWeight.Should().Be(200);
            drones[1].Name.Should().Be("DroneB");
            drones[1].MaximumWeight.Should().Be(250);
            drones[2].Name.Should().Be("DroneC");
            drones[2].MaximumWeight.Should().Be(100);
        }

        [Fact]
        public void Parse_InvalidLines_ThrowsBadlyFormattedFileException()
        {
            // Arrange
            var parser = new DroneParser();
            var lines = new List<string> { "[InvalidFormat]" };

            // Act
            Action act = () => parser.Parse<Drone>(lines);

            // Assert
            act.Should().Throw<BadlyFormattedFileException>()
                .WithMessage("No matches for drones were found.");
        }
    }
}