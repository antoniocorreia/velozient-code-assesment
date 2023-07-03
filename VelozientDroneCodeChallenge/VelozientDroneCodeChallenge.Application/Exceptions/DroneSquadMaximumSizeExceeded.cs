using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelozientDroneCodeChallenge.Application.Exceptions
{
    public class DroneSquadMaximumSizeExceeded : Exception
    {
        public DroneSquadMaximumSizeExceeded() : base("Drone squad maximum size exceeded. Your squad must have a maximum of 100 drones.") { }
    }
}
