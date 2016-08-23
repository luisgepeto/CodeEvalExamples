using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniQue_elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);
            foreach (var line in lines)
            {
                var removedDuplicates = RemoveDuplicates(line);
                for (int i = 0; i < removedDuplicates.Count; i++)
                {
                    Console.Write(removedDuplicates.ElementAt(i));
                    if (i != removedDuplicates.Count - 1)
                        Console.Write(',');
                }
                Console.WriteLine("");
            }
        }

        static List<string> RemoveDuplicates(string line)
        {
            var lineArray = line.Split(',').ToList();            
            return lineArray.GroupBy(p => p).Select(p => p.Key).ToList();            
        }
    }
}
