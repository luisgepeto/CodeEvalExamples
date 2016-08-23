using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decimal_to_binary
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);
            foreach(var line in lines){
                var number = Int32.Parse(line);
                var binaryString = ConvertToBinaryString(number, "");
                Console.WriteLine(binaryString);
            }            
        }

        static string ConvertToBinaryString(int number, string previousString)
        {
            if (number < 2)
            {
                previousString = number+ previousString;
            }
            else
            {
                previousString = number % 2+previousString;
                previousString = ConvertToBinaryString(number / 2, previousString);
            }
            return previousString;
        }
    }
}
