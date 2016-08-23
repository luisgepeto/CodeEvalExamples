using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armstrong_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);
            foreach (var line in lines)
            {
                var number = Int32.Parse(line);
                if (IsArmstrong(number))
                    Console.WriteLine("True");
                else
                    Console.WriteLine("False");
            }            
        }

        static bool IsArmstrong(int n)
        {
            if (n == CalculateSum(n))
                return true;
            return false;
        }

        static double CalculateSum(int n)
        {
            var absN = Math.Abs(n).ToString();
            var absLength = absN.Length;
            var absNList = absN.ToCharArray().Select(p => (int)Char.GetNumericValue(p)).ToList();
            return absNList.GroupBy(p => true).Select(p => p.Sum(k => Math.Pow(k,absLength))).FirstOrDefault();            
        }
    }
}
