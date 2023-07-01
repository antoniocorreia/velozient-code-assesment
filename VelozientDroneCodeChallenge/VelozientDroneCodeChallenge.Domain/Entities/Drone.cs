using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelozientDroneCodeChallenge.Model
{
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
}
