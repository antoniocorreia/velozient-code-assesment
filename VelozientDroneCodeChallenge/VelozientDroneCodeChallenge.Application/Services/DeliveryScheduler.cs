using VelozientDroneCodeChallenge.Application.Interfaces;
using VelozientDroneCodeChallenge.Application.Model;
using VelozientDroneCodeChallenge.Domain.Entities;

namespace VelozientDroneCodeChallenge.Infrasctructure.Services;

public class DeliveryScheduler : IScheduler
{
    public List<Trip> Execute(FileResult dronesAndLocations)
    {
        var drones = dronesAndLocations.Drones.OrderByDescending(d => d.MaximumWeight).ToList();
        var locations = dronesAndLocations.Locations;

        List<Trip> trips = new List<Trip>();
        
        int totalPackages = locations.Sum(l => l.PackageWeight);

        while (totalPackages > 0)
        {
            foreach (Drone drone in drones)
            {
                
                int remainingWeight = drone.MaximumWeight;
                int tripCode = trips.Where(t=>t.Drone.Name.Equals(drone.Name)).Count() + 1;
                Trip droneTrip = new Trip(drone, tripCode);

                foreach (Location location in locations.Where(l => l.PackageWeight > 0))
                {
                    
                    if (location.PackageWeight <= remainingWeight)
                    {
                        remainingWeight = remainingWeight - location.PackageWeight;
                        totalPackages = totalPackages - location.PackageWeight;

                        droneTrip.Locations.Add(location);
                        
                        location.PackageWeight = 0;
                        
                        
                    }

                    if (remainingWeight == 0)
                    {
                        break;
                    }
                }

               
                trips.Add(droneTrip);
                

                if (totalPackages <= 0)
                {
                    break;
                }

            }
        }
        return trips;
    }
}
