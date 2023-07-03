using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelozientDroneCodeChallenge.Application.Exceptions;
using VelozientDroneCodeChallenge.Domain.Entities;
using VelozientDroneCodeChallenge.Infrasctructure.Parser;

namespace VelozientDroneCodeChallenge.Tests.ParseTests
{
    public class LocationParsersTests
    {
        [Fact]
        public void Parse_ValidLines_ReturnsListOfLocations()
        {
            // Arrange
            var parser = new LocationParser();
            var lines = new List<string>
            {
                "[DroneA], [200], [DroneB], [250], [DroneC], [100]",
                "[LocationA], [200]",
                "[LocationB], [150]",
                "[LocationC], [50]",
                "[LocationD], [150]"
            };

            // Act
            var result = parser.Parse<Location>(lines);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(4);

            var locations = result.ToList();
            locations[0].Name.Should().Be("LocationA");
            locations[0].PackageWeight.Should().Be(200);
            locations[1].Name.Should().Be("LocationB");
            locations[1].PackageWeight.Should().Be(150);
            locations[2].Name.Should().Be("LocationC");
            locations[2].PackageWeight.Should().Be(50);
            locations[3].Name.Should().Be("LocationD");
            locations[3].PackageWeight.Should().Be(150);
        }

        [Fact]
        public void Parse_InvalidLines_ThrowsBadlyFormattedFileException()
        {
            // Arrange
            var parser = new LocationParser();
            var lines = new List<string> { "[InvalidFormat]" };

            // Act
            Action act = () => parser.Parse<Location>(lines);

            // Assert
            act.Should().Throw<BadlyFormattedFileException>()
                .WithMessage("No matches for locations were found.");
        }
    }
}

