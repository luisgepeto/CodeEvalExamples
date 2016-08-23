using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPositions
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);
            foreach (string line in lines)
            {
                var parameters = GetParameters(line);
                var areEqual = CompareBits(parameters.n, parameters.p1, parameters.p2);
                if (areEqual)
                    Console.WriteLine("true");
                else
                    Console.WriteLine("false");                
            }
        }

        private static Parameters GetParameters(string line){
            var commaParameterArray = line.Split(',');
            return new Parameters(){
                n = Int32.Parse(commaParameterArray[0]),
                p1= Int32.Parse(commaParameterArray[1]),
                p2 = Int32.Parse(commaParameterArray[2])
            };
        }

        private static bool CompareBits(int n, int p1, int p2)
        {
            var booleanString = ConvertToBoolean(n);
            var booleanArray = booleanString.ToCharArray();
            if(booleanArray[p1-1] == booleanArray[p2-1])
                return true;
            return false;
        }

        private static string ConvertToBoolean(int n)
        {
            if (n / 2 == 0)
                return "" + n % 2;
            else
                return n% 2 + ConvertToBoolean(n / 2);
        }
    }

    class Parameters {
        public int n { get; set; }
        public int p1 { get; set; }
        public int p2 { get; set; }
    }
}
