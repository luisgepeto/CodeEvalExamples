using System;
using System.Collections.Generic;
using System.Linq;


namespace pascals_triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);
            foreach (var line in lines)
            {
                var depth = Int32.Parse(line);
                var pascalLine = GetPascalLine(depth);
                var pascalLength = pascalLine.Count;
                for (var i = 0; i < pascalLength; i++)
                {
                    Console.Write(pascalLine.ElementAt(i));
                    if (i == pascalLength - 1)
                        Console.WriteLine("");
                    else
                        Console.Write(" ");
                }
            }
        }

        static List<int> GetPascalLine(int depth)
        {
            List<int> outPascal = new List<int>();
            List<int> previousRow = new List<int>();            
            for (var i = 0; i < depth; i++)
            {
                var currentRow = GetNextPascalRow(previousRow);
                previousRow = currentRow;
                outPascal.AddRange(previousRow);   
            }
            return outPascal;
        }

        static List<int> GetNextPascalRow(List<int> previousRow)
        {
            if (!previousRow.Any())
            {
                return new List<int>() { 1 };
            }
            else
            {
                var auxList = new List<int>();
                for (var i = 0; i < previousRow.Count - 1; i++)
                {
                    var newElement = previousRow.ElementAt(i) + previousRow.ElementAt(i + 1);
                    auxList.Add(newElement);
                }
                auxList.Add(1);
                var initialList = new List<int>() { 1 };
                initialList.AddRange(auxList);
                return initialList;
            }
        }
    }
}
