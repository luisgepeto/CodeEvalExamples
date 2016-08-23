using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplication_Tables
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 12; i++)
            {
                var line = "";
                for (int j = 1; j <= 12; j++)
                    line = AppendFormattedNumber(i * j, line);
                Console.WriteLine(line.Trim());
            }
                
        }

        private static string AppendFormattedNumber(int k, string line)
        {
            return line + FormatNumber(k);
        }

        private static string FormatNumber(int k)
        {
            var length = ("" + k).Length;            
            string formattedNumber = String.Empty;
            switch (length)
            {
                case 1:
                    formattedNumber = "   "+k;
                    break;
                case 2:
                    formattedNumber = "  " + k;
                    break;
                case 3:
                    formattedNumber = " " + k;
                    break;
                case 4:
                default:
                    formattedNumber = ""+ k;
                    break;
            }
            return formattedNumber;
        }
    }
}
