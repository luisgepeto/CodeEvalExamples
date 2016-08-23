using System;
using System.Linq;


    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1000; i >= 2; i--)
            {
                if (IsPrime(i))
                    if (IsPalindrome(i))
                    {
                        Console.Write(i);
                        break;
                    }                        
            }
        }

        private static bool IsPrime(int number)
        {
            for (int i = 2; i <= Math.Ceiling(Math.Sqrt(number)); i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
        private static bool IsPalindrome(int number)
        {
            char[] numberArray = ("" + number).ToCharArray();
            if (IsPalindrome(numberArray))
                return true;
            return false;
        }

        private static bool IsPalindrome(char[] number)
        {
            for (int i = 0; i < (int)Math.Ceiling(number.Length / 2.0); i++)
            {
                if (number[i] != number[number.Length - i - 1])
                    return false;
            }
            return true;
        }

    }
