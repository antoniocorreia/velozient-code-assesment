using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelozientDroneCodeChallenge.Infrasctructure.Parser;
using VelozientDroneCodeChallenge.Model;

namespace VelozientDroneCodeChallenge.Infrasctructure
{
    public class InputReader
    {
        public static void ReadFile(string path)
        {
            var enumLines = File.ReadLines(path, Encoding.UTF8);

            foreach (var line in enumLines)
            {
                Console.WriteLine(line);
            }

            DroneParser droneParser = new DroneParser();
            List<Drone> drones = droneParser.Parse<Drone>(enumLines);

            LocationParser locationParser = new LocationParser();
            List<Location> locations = locationParser.Parse<Location>(enumLines);
        }
    }
}
