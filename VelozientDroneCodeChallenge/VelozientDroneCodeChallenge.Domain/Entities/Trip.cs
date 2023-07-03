namespace VelozientDroneCodeChallenge.Domain.Entities;

public class Trip
{
    public Drone Drone { get; }
    public int Code { get; }
    public List<Location> Locations { get; }

    public Trip(Drone drone, int code, List<Location> locations)
    {
        this.Drone = drone;
        this.Code = code;
        this.Locations = locations;
    }

    public Trip(Drone drone, int code)
    {
        this.Drone = drone;
        this.Locations = new List<Location>();
        this.Code = code;
    }

    public Trip(Drone drone) : this(drone, 1) 
    {
    }


}
