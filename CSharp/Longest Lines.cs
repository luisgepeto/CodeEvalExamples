using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longest_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);
            var numberOfLines = Int32.Parse(lines[0]);
            var textLines = lines.Skip(1);
            textLines = textLines.OrderByDescending(t => t.Length);
            var output = textLines.Take(numberOfLines).ToList();
            foreach(var line in output){
                Console.WriteLine(line);
            }            
        }
    }
}
