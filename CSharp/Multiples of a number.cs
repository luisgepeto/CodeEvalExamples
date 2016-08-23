using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiples_of_a_number
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);
            foreach (string line in lines)
            {
                if (!String.IsNullOrEmpty(line))
                {
                    int multiple = ObtainMultiples(line);
                    Console.Write(multiple);
                    Console.Write("\n");
                }                
            }
        }

        private static int ObtainMultiples(string line)
        {
            Parameters parameters = ObtainParameters(line);

            int multiple = parameters.n;
            int multiplier = 1;
            while (multiple*multiplier < parameters.x)
            {                
                multiplier++;
            }
            return multiple*multiplier;
        }

        private static Parameters ObtainParameters(string line)
        {
            string[] lineArray = line.Split(',');
            return new Parameters()
            {
                x = Int32.Parse(lineArray[0]),
                n = Int32.Parse(lineArray[1]),
            };
        }
    }
    class Parameters
    {
        public int x { get; set; }
        public int n { get; set; }
    }
}
