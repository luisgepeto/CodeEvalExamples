using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pangrams
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);
            foreach (var line in lines)
            {
                var output = MissingPangramLetters(line);
                if (output.Count > 0)
                {
                    foreach (var letter in output)
                        Console.Write(letter);
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("NULL");
                }                
            }
        }

        static List<string> MissingPangramLetters(string line)
        {
            var missingList = new List<string>();
            for (var i = 65; i < 91; i++)
            {
                var array1 = new Byte[]{(byte)i};
                var array2 = new Byte[]{(byte)(i+32)};
                if (!line.Contains(Encoding.ASCII.GetString(array1)) && !line.Contains(Encoding.ASCII.GetString(array2)))
                    missingList.Add(Encoding.ASCII.GetString(array2));
            }
            return missingList;
        }
    }
}
