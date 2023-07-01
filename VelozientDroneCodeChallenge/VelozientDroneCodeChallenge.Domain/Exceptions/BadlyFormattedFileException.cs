using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelozientDroneCodeChallenge.Domain.Exceptions
{
    public class BadlyFormattedFileException : Exception
    {
        public BadlyFormattedFileException(string type) : base($"No matches for \"{type}\" was found.") { }
    }
}
