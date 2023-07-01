using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelozientDroneCodeChallenge.Infrasctructure.Parser
{
    internal interface IParser
    {
        List<T> Parse<T>(string input);
    }
}
