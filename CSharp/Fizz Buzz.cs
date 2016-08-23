using System;
using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);            
            foreach (string line in lines)
            {
                ConvertToFizzBuzz(line);
                Console.Write("\n");
            }
        }

        private static void ConvertToFizzBuzz(string line)
        {
            Parameters myParameters = ExtractParametersFromLine(line);
            ApplyFizzBuzzAlgorithm(myParameters);
        }

        private static Parameters ExtractParametersFromLine(string line)
        {
            string[] lineComponents = line.Split(' ');
            return new Parameters()
            {
                x = Int32.Parse(lineComponents[0]),
                y = Int32.Parse(lineComponents[1]),
                n = Int32.Parse(lineComponents[2])
            };
        }

        private static void ApplyFizzBuzzAlgorithm(Parameters parameters)
        {
            for (int i = 1; i <= parameters.n; i++)
            {
                PrintCurrentFizzBuzz(i, parameters);
                if (i != parameters.n)
                    Console.Write(" ");
            }
        }
 
        private static void PrintCurrentFizzBuzz(int i, Parameters parameters)
        {
            if (i % parameters.x == 0 && i % parameters.y == 0)
                Console.Write("FB");
            else if (i % parameters.x == 0)
                Console.Write("F");
            else if (i % parameters.y == 0)
                Console.Write("B");
            else
                Console.Write(i);
        }
    }

    class Parameters
    {
        public int x { get; set; }
        public int y { get; set; }
        public int n { get; set; }
    }
