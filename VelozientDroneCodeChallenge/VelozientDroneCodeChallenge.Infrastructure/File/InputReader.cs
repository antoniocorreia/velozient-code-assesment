using System.Text;
using VelozientDroneCodeChallenge.Application.Model;

namespace VelozientDroneCodeChallenge.Infrasctructure;

public class InputReader
{
    public static FileResult ReadFile(string path)
    {
        var enumLines = File.ReadLines(path, Encoding.UTF8);

        DroneParser droneParser = new DroneParser();
        List<Drone> drones = droneParser.Parse<Drone>(enumLines);

        LocationParser locationParser = new LocationParser();
        List<Location> locations = locationParser.Parse<Location>(enumLines);

        return new FileResult(drones, locations);
    }
}

