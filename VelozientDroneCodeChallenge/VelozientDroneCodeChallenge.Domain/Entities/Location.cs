namespace VelozientDroneCodeChallenge.Domain.Entities;
public class Location
{
    public string Name { get; }
    public int PackageWeight { get; set; }
    public Location(string name, int packageWeight)
    {
        this.Name = name;
        this.PackageWeight = packageWeight;
    }

}
