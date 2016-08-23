using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_of_primes
{
    class Program
    {
        static void Main(string[] args)
        {
            int primeCount = 0;
            int sum =0;
            int currentNumber = 2;
            while (primeCount < 1000)
            {
                if (IsPrime(currentNumber))
                {
                    sum += currentNumber;
                    primeCount++;
                }
                currentNumber++;
            }
            Console.Write(sum);
        }
        private static bool IsPrime(int number)
        {
            if (number <= 3)
            {
                return number > 1;
            }            
            for (int i = 2; i <= Math.Ceiling(Math.Sqrt(number)); i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
    }
}
