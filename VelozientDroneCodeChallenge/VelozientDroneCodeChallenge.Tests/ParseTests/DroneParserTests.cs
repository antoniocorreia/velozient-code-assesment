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

        [Fact]
        public void Parse_InvalidSquadSize_ThrowsDroneSquadMaximumSizeExceededException()
        {
            // Arrange
            var parser = new DroneParser();
            var lines = new List<string> { "[DroneA], [200], [DroneB], [250], [DroneC], [100], [DroneD], [150], [DroneE], [180], [DroneF], [220], [DroneG], [300], [DroneH], [120], [DroneI], [250], [DroneJ], [200], [DroneK], [150], [DroneL], [100], [DroneM], [280], [DroneN], [160], [DroneO], [220], [DroneP], [190], [DroneQ], [210], [DroneR], [180], [DroneS], [240], [DroneT], [270], [DroneU], [230], [DroneV], [200], [DroneW], [220], [DroneX], [190], [DroneY], [170], [DroneZ], [150], [DroneAA], [250], [DroneAB], [270], [DroneAC], [280], [DroneAD], [190], [DroneAE], [200], [DroneAF], [210], [DroneAG], [230], [DroneAH], [180], [DroneAI], [260], [DroneAJ], [240], [DroneAK], [220], [DroneAL], [150], [DroneAM], [170], [DroneAN], [200], [DroneAO], [230], [DroneAP], [250], [DroneAQ], [210], [DroneAR], [270], [DroneAS], [220], [DroneAT], [200], [DroneAU], [180], [DroneAV], [190], [DroneAW], [210], [DroneAX], [240], [DroneAY], [160], [DroneAZ], [270], [DroneBA], [220], [DroneBB], [250], [DroneBC], [230], [DroneBD], [260], [DroneBE], [190], [DroneBF], [180], [DroneBG], [170], [DroneBH], [150], [DroneBI], [240], [DroneBJ], [210], [DroneBK], [200], [DroneBL], [220], [DroneBM], [250], [DroneBN], [230], [DroneBO], [270], [DroneBP], [190], [DroneBQ], [280], [DroneBR], [200], [DroneBS], [210], [DroneBT], [240], [DroneBU], [220], [DroneBV], [180], [DroneBW], [160], [DroneBX], [190], [DroneBY], [170], [DroneBZ], [150], [DroneCA], [260], [DroneA], [200], [DroneB], [250], [DroneC], [100], [DroneD], [150], [DroneE], [180], [DroneF], [220], [DroneG], [300], [DroneH], [120], [DroneI], [250], [DroneJ], [200], [DroneK], [150], [DroneL], [100], [DroneM], [280], [DroneN], [160], [DroneO], [220], [DroneP], [190], [DroneQ], [210], [DroneR], [180], [DroneS], [240], [DroneT], [270], [DroneU], [230], [DroneV], [200], [DroneW], [220], [DroneX], [190], [DroneY], [170], [DroneZ], [150], [DroneAA], [250], [DroneAB], [270], [DroneAC], [280], [DroneAD], [190], [DroneAE], [200], [DroneAF], [210], [DroneAG], [230], [DroneAH], [180], [DroneAI], [260], [DroneAJ], [240], [DroneAK], [220], [DroneAL], [150], [DroneAM], [170], [DroneAN], [200], [DroneAO], [230], [DroneAP], [250], [DroneAQ], [210], [DroneAR], [270], [DroneAS], [220], [DroneAT], [200], [DroneAU], [180], [DroneAV], [190], [DroneAW], [210], [DroneAX], [240], [DroneAY], [160], [DroneAZ], [270], [DroneBA], [220], [DroneBB], [250], [DroneBC], [230], [DroneBD], [260], [DroneBE], [190], [DroneBF], [180], [DroneBG], [170], [DroneBH], [150], [DroneBI], [240], [DroneBJ], [210], [DroneBK], [200], [DroneBL], [220], [DroneBM], [250], [DroneBN], [230], [DroneBO], [270], [DroneBP], [190], [DroneBQ], [280], [DroneBR], [200], [DroneBS], [210], [DroneBT], [240], [DroneBU], [220], [DroneBV], [180], [DroneBW], [160], [DroneBX], [190], [DroneBY], [170], [DroneBZ], [150], [DroneCA], [260]" };

            // Act
            Action act = () => parser.Parse<Drone>(lines);

            // Assert
            act.Should().Throw<DroneSquadMaximumSizeExceeded>();
                
        }
    }
}