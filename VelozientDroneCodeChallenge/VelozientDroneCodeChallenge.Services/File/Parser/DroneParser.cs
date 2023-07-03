using System.Text.RegularExpressions;

namespace VelozientDroneCodeChallenge.Infrasctructure.Parser;

public class DroneParser : IParser
{
    private string Pattern { get; set; }
    public DroneParser() {
        Pattern = @"\[(?<name>\w+)\], \[(?<maximumWeight>\d+)\]";
    }
    public List<T> Parse<T>(IEnumerable<string> lines)
    {
        MatchCollection matches = Regex.Matches(lines.First(), Pattern);
        
        if(matches.Count == 0) throw new BadlyFormattedFileException("drones");

        List<Drone> drones = new List<Drone>();

        foreach (Match match in matches)
        {
            drones.Add(new Drone(match.Groups["name"].Value, int.Parse(match.Groups["maximumWeight"].Value)));
        }

        return new List<T>(drones as IEnumerable<T> ?? throw new BadlyFormattedFileException("drones"));
    }
}
