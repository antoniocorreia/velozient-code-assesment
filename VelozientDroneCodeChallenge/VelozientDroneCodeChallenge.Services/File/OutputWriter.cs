using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelozientDroneCodeChallenge.Infrasctructure
{
    public class OutputWriter
    {
        public static void Write(string path, string text)
        {
            File.WriteAllText(path, text);

            Console.WriteLine("text written");
        }
    }
}
