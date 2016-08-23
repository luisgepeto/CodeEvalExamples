using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credit_Card
{
    class Program
    {
        static void Main(string[] args)
        {
             string[] lines = System.IO.File.ReadAllLines(args[0]);            
            foreach (string line in lines)
            {
                var valid = CheckValidity(line);
                Console.WriteLine(valid ? 1 : 0);
            }
        }

        public static bool CheckValidity(string line)
        {
            var cardNumber = line.Replace(" ", String.Empty);
            var sum = GetChecksum(cardNumber);
            return sum % 10 == 0;
        }
 
        private static int GetChecksum(string cardNumber)
        {
            var invertedCardNumber = cardNumber.Reverse();
            var cardLength = cardNumber.Length;
            var sum = 0;
            for (var i = 0; i < cardLength; i++)
            {
                var currentDigit = Int32.Parse(""+invertedCardNumber.ElementAt(i));
                if (i % 2 == 1)
                {
                    currentDigit *= 2;
                }
                if (currentDigit == 9 || currentDigit == 18)
                {
                    sum += 9;
                }
                else
                {
                    sum += currentDigit % 9;
                }
            }
            return sum;
        }
    }
}
