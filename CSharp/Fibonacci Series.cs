using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci_Series
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);
            foreach (string line in lines)
            {
                int position = Int32.Parse(line);
                var digit = FindFibonacci(position);
                Console.WriteLine(digit);
            }
        }

        private static int FindFibonacci(int position)
        {
            if (position == 0)
                return 0;
            else if (position == 1)
                return 1;
            else
                return FindFibonacci(position - 1) + FindFibonacci(position - 2);
        }

        
    }
}
