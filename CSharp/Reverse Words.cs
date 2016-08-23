using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);
            foreach (string line in lines)
            {
                if (!String.IsNullOrEmpty(line))
                {
                    Reverse(line);
                    Console.Write("\n");
                }                    
            }
        }

        private static void Reverse(string line)
        {
            string[] words = line.Split(' ');
            ReverseArray(words);
        }

        private static void ReverseArray(string[] words)
        {
            for (int i = words.Length - 1; i >= 0; i--)
            {
                Console.Write(words[i]);
                if (i != 0)
                    Console.Write(" ");
            }
        }
    }
}
