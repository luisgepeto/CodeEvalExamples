using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mth_To_last_element
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);
            foreach (var line in lines)
            {                
                var parameters = GetParameters(line);
                if (parameters.Index <= parameters.Elements.Count)
                {
                    Console.WriteLine(parameters.Elements.ElementAt(parameters.Index - 1));
                }
            }
        }

        private static Parameters GetParameters(string line)
        {            
            var index = line.Split(' ').Reverse().First();
            var elements = line.Split(' ').Reverse().Skip(1).ToList();
            return new Parameters()
            {
                Index = Int32.Parse(index),
                Elements = elements
            };
        }
    }

    class Parameters{
        public List<string> Elements{ get; set; }
        public int Index { get; set; }
    }
}
