using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelozientDroneCodeChallenge.Application.Exceptions
{
    public class MaximumPackageWeightExceeded : Exception
    {
        public MaximumPackageWeightExceeded(int maximumWeight) : base($"Location maximum package weight exceeded. The locations package weight must not exceed {maximumWeight}.") { }
    }
}
