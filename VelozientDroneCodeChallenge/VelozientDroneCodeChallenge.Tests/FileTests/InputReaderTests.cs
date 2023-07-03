using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelozientDroneCodeChallenge.Application.Exceptions;
using VelozientDroneCodeChallenge.Application.Model;
using VelozientDroneCodeChallenge.Infrasctructure;

namespace VelozientDroneCodeChallenge.Tests.FileTests
{
    public class InputReaderTests
    {
        [Fact]
        public void ReadFile_ValidPath_ReturnsFileResult()
        {
            // Arrange
            string path = "testfile.txt"; 
            string[] fileLines = new string[]
            {
                "[DroneA], [200], [DroneB], [250], [DroneC], [100]",
                "[LocationA], [200]",
                "[LocationB], [150]",
                "[LocationC], [50]",
                "[LocationD], [150]",
                "[LocationE], [100]"
            };
            File.WriteAllLines(path, fileLines);

            // Act
            FileResult result = InputReader.ReadFile(path);

            // Assert
            result.Should().NotBeNull();
            result.Drones.Should().NotBeNull();
            result.Locations.Should().NotBeNull();
            result.Drones.Should().HaveCount(3);
            result.Locations.Should().HaveCount(5);

            // Clean up
            File.Delete(path);
        }

        [Fact]
        public void ReadFile_InvalidPath_ThrowsFileNotFoundException()
        {
            // Arrange
            string invalidPath = "invalidpath.txt";

            // Act
            Action ac = () => { InputReader.ReadFile(invalidPath); };

            // Assert
            ac.Should().Throw<FileNotFoundException>();
        }

        [Fact]
        public void ReadFile_InvalidLocationPackageWeight_ThrowsMaximumPackageWeightExceededException()
        {
            // Arrange
            string path = "testfile.txt";
            string[] fileLines = new string[]
            {
                "[DroneA], [200], [DroneB], [250], [DroneC], [100]",
                "[LocationA], [300]",
                "[LocationB], [150]",
                "[LocationC], [50]",
                "[LocationD], [150]",
                "[LocationE], [100]"
            };
            File.WriteAllLines(path, fileLines);

            // Act
            Action act = () => InputReader.ReadFile(path);

            // Assert
            act.Should().Throw<MaximumPackageWeightExceeded>();

            // Clean up
            File.Delete(path);
        }
    }
}
