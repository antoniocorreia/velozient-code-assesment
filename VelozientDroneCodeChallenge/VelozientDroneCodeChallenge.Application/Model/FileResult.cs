using VelozientDroneCodeChallenge.Domain.Entities;

namespace VelozientDroneCodeChallenge.Application.Model;

public class FileResult
{
    public List<Drone> Drones { get; set; }
    public List<Location> Locations { get; set; }

    public FileResult()
    {
        Drones = new List<Drone>();
        Locations = new List<Location>();
    }

    public FileResult(List<Drone> drones, List<Location> locations)
    {
        Drones = drones;
        Locations = locations;
    }
}
