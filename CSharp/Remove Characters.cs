using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remove_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);
            foreach (var line in lines)
            {
                var parameters = GetParameters(line);
                parameters.MakeRemoval();
                Console.WriteLine(parameters.Text);
            }
        }
        static Parameters GetParameters(string line)
        {
            return new Parameters()
            {
                Text = line.Split(',').ElementAt(0),
                ToRemove = line.Split(' ').Last().Select(a => a+"").ToList()
            };
        }
    }
    class Parameters
    {
        public string Text { get; set; }
        public List<string> ToRemove { get; set; }

        public void MakeRemoval()
        {
            var result= Text.Where(a => !ToRemove.Contains(a+""));
            var emptyString = "";
            foreach (var letter in result)
            {
                emptyString+=letter;                
            }
            Text = emptyString;
        }
    }
}
