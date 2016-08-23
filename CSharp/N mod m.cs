using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_mod_m
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);
            foreach (var line in lines)
            {
                var parameters = GetParameters(line);
                var modulus = GetModulus(parameters.N, parameters.M);
                Console.WriteLine(modulus);
            }
        }
        static Parameters GetParameters(string line)
        {
            var splitLine =  line.Split(',');
            return new Parameters
            {
                N = Int32.Parse(splitLine[0]),
                M = Int32.Parse(splitLine[1]),
            };
        }
        static int GetModulus(int n, int m)
        {
            var division = n / m;
            return n - division * m;
        }
    }
    
    class Parameters
    {
        public int N { get; set; }
        public int M { get; set; }
    }
}
