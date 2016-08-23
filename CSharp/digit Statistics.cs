using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digit_Statistics
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);
            foreach (var line in lines)
            {
                var parameters = new Parameters(line);
                parameters.PrintStatistics();
            }
        }
    }

    class Parameters
    {
        public int A { get; set; }
        public long N { get; set; }

        public Parameters(string line)
        {
            A = Int32.Parse(line.Split(' ')[0]);
            N = Int64.Parse(line.Split(' ')[1]);
        }
        public int ModulusFactor
        {
            get { return LastDigitList.Count; }
        }

        public List<int> LastDigitList
        {
            get
            {
                var lastDigitList = new List<int>();
                switch (A+"")
                {
                    case("2"):
                        lastDigitList.Add(2);
                        lastDigitList.Add(4);
                        lastDigitList.Add(8);
                        lastDigitList.Add(6);
                        break;
                    case("3"):
                        lastDigitList.Add(3);
                        lastDigitList.Add(9);
                        lastDigitList.Add(7);
                        lastDigitList.Add(1);
                        break;
                    case("4"):
                        lastDigitList.Add(4);
                        lastDigitList.Add(6);
                        break;
                    case("5"):
                        lastDigitList.Add(5);
                        break;
                    case("6"):
                        lastDigitList.Add(6);
                        break;
                    case("7"):
                        lastDigitList.Add(7);
                        lastDigitList.Add(9);
                        lastDigitList.Add(3);
                        lastDigitList.Add(1);
                        break;
                    case("8"):
                        lastDigitList.Add(8);
                        lastDigitList.Add(4);
                        lastDigitList.Add(2);
                        lastDigitList.Add(6);
                        break;
                    case("9"):
                        lastDigitList.Add(9);
                        lastDigitList.Add(1);
                        break;
                }
                return lastDigitList;
            }
        } 

        public Dictionary<int, long> RepetitionsCount
        {
            get 
            {
                var emptyDictionary = InstantiateEmptyDictionary();
                var modulus = N%ModulusFactor;
                var completeIteration = N/ModulusFactor;

                for (var i = 0; i < ModulusFactor; i++)
                {
                    emptyDictionary[LastDigitList.ElementAt(i)] = completeIteration;
                }
                for (var i = 0; i < modulus; i++)
                {
                    emptyDictionary[LastDigitList.ElementAt(i)]++;
                }
                return emptyDictionary;
            }
        }

        private Dictionary<int, long> InstantiateEmptyDictionary()
        {
            var emptyDictionary = new Dictionary<int, long>();
            for (var i = 0; i < 10; i++)
            {
                emptyDictionary.Add(i, 0);
            }
            return emptyDictionary;
        }

        public void PrintStatistics()
        {
            for (var i = 0; i < 10; i++)
            {
                var repetitionsCount = RepetitionsCount;
                Console.Write(String.Format("{0}: {1}", i, repetitionsCount[i]));
                if (i != 9)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine("");
        }
    }
}
