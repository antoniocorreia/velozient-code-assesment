using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace VelozientDroneCodeChallenge.Infrasctructure.Parser;

public class LocationParser : IParser
{
    private string Pattern { get; set; }
    public LocationParser() {
        this.Pattern = @"\[(?<name>\w+)\], \[(?<packageWeight>\d+)\]";
    }
    public List<T> Parse<T>(IEnumerable<string> lines)
    {
        MatchCollection matches = Regex.Matches(String.Join(string.Empty,lines.Skip(1)), this.Pattern);
       
        if (matches.Count == 0) throw new BadlyFormattedFileException("locations");

        List<Location> locations = new List<Location>();

        foreach (Match match in matches)
        {
            locations.Add(new Location(match.Groups["name"].Value, int.Parse(match.Groups["packageWeight"].Value)));
        }

        return new List<T>(locations as IEnumerable<T> ?? throw new BadlyFormattedFileException("locations"));
    }
}
