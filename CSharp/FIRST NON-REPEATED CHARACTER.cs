using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIRST_NON_REPEATED_CHARACTER
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);
            foreach (var line in lines)
            {
                var firstChar = GetNonRepeatedChar(line);
                Console.WriteLine(firstChar);
            }
        }
        private static char GetNonRepeatedChar(string line)
        {
            char outChar = ' ';
            var charArray = line.ToCharArray();
            var groupedChar = charArray.GroupBy(g => g)
                                            .Select(g => new GroupedChar
                                            {
                                                Char = g.Key,
                                                Count = g.Count()
                                            })
                                            .Where(s => s.Count == 1)
                                            .FirstOrDefault();
            if(groupedChar!= null)
                outChar = groupedChar.Char;
            return outChar;
        }
    }
    class GroupedChar
    {
        public char Char { get; set; }
        public int Count { get; set; }
    }
}
