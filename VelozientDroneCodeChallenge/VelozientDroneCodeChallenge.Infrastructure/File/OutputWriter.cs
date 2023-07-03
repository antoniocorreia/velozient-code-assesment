namespace VelozientDroneCodeChallenge.Infrasctructure;
public class OutputWriter : IOutputWriter
{
    public void Write(string path, List<Trip> trips)
    {
        List<string> lines = new List<string>();
        IEnumerable<IGrouping<string,Trip>> groupTripsByDrone = trips.GroupBy(t=>t.Drone.Name).OrderBy(t=>t.Key);

        foreach (IGrouping<string, Trip> group in groupTripsByDrone)
        {
            lines.Add($"[{group.Key}]");
            Console.WriteLine(group.Key);

            foreach (Trip trip in group)
            {
                if(trip.Locations.Count > 0)
                {
                    lines.Add($"Trip #{trip.Code}");
                    
                    Console.WriteLine($"Trip #{trip.Code}");

                    var locations = String.Join(", ", trip.Locations.Select(l => $"[{l.Name}]"));
                    lines.Add(locations);
                    
                    Console.WriteLine(locations);
                }
            }
            
            lines.Add(Environment.NewLine);
        }

        Console.WriteLine("Saving file output.txt, check your output directory.");
        File.WriteAllLines(path, lines);
    }
}

