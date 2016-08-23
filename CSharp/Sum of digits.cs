using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_of_digits
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);
            foreach (string line in lines)
            {
                var sum = SumDigits(line);
                Console.WriteLine(sum);
            }
        }

        private static int SumDigits(string line)
        {
            var lineArray = line.ToCharArray();
            int sum = 0;
            foreach (var digit in lineArray)
            {
                sum += Int32.Parse(""+digit);
            }
            return sum;
        }
    }
}
