using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);
            foreach (var line in lines)
            {
                var number = Int32.Parse(line);
                Dictionary<int, bool> hasBeenVisited = new Dictionary<int, bool>();
                hasBeenVisited.Add(number, true);
                var result = IsHappy(number, hasBeenVisited);
                Console.WriteLine(result);
            }
        }

        static int IsHappy(int number, Dictionary<int, bool> visited)
        {
            var sum = CalculateSum(number);            
            if (sum == 1)
            {
                return 1;
            }
            else if(visited.ContainsKey(sum))
            {
                return 0;
            }
            else
            {
                visited.Add(sum, true);
                return IsHappy(sum, visited);
            }
        }

        static int CalculateSum(int n)
        {
            var absN = Math.Abs(n).ToString();
            var absNList = absN.ToCharArray().Select(p => (int)Char.GetNumericValue(p)).ToList();
            return absNList.GroupBy(p => true).Select(p => p.Sum(k => k*k)).FirstOrDefault();            
        }
    }
    
}
