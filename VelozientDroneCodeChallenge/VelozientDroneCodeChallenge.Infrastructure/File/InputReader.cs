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

        int maxDroneCapacity = drones.Max(x => x.MaximumWeight);
        int maxLocationCapacity = locations.Max(x => x.PackageWeight);

        if (maxLocationCapacity > maxDroneCapacity) throw new MaximumPackageWeightExceeded(maxLocationCapacity);

        return new FileResult(drones, locations);
    }
}

