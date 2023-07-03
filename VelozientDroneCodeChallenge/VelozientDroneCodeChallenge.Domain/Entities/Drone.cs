namespace VelozientDroneCodeChallenge.Domain.Entities;
public class Drone
{
    public string Name { get; }
    public int MaximumWeight { get; }

    public Drone(string name, int maximumWeight)
    {
        this.Name = name;
        this.MaximumWeight = maximumWeight;
    }

}
