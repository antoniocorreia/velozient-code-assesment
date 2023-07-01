using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VelozientDroneCodeChallenge.Domain.Exceptions;
using VelozientDroneCodeChallenge.Model;

namespace VelozientDroneCodeChallenge.Infrasctructure.Parser
{
    public class DroneParser : IParser
    {
        public List<T> Parse<T>(IEnumerable<string> lines)
        {
            string pattern = @"\[(\w+)\], \[(\d+)\]";
            MatchCollection matches = Regex.Matches(lines.First(), pattern);
            List<Drone> drones = new List<Drone>();

            if(matches.Count == 0) throw new BadlyFormattedFileException("drones");

            foreach(Match match in matches)
            {
                drones.Add(new Drone(match.Groups[1].Value, int.Parse(match.Groups[2].Value)));
            }

            return new List<T>(drones as IEnumerable<T> ?? throw new InvalidOperationException());
        }
    }
}
