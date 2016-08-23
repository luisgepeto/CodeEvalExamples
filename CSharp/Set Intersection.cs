using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set_Intersection
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);
            foreach (var line in lines)
            {
                var sequences = line.Split(';');
                List<int> list1 = sequences[0].Split(',').Select(l => Int32.Parse(l)).ToList();
                List<int> list2 = sequences[1].Split(',').Select(l => Int32.Parse(l)).ToList();

                var intersect = list1.Intersect(list2);
                if (intersect.Any())
                {
                    for (var i = 0; i < intersect.Count(); i++)
                    {
                        Console.Write(intersect.ElementAt(i));
                        if (i < intersect.Count() - 1)
                            Console.Write(",");
                    }
                }
                Console.WriteLine("");                
            }
        }
    }
}
