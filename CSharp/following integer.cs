using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace following_integer
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);
            foreach (var line in lines)
            {
                var currentNumber = Int32.Parse(line);
                var nextNumber = GetNextNumber(currentNumber);
                Console.WriteLine(nextNumber);
            }
        }
        static int GetNextNumber(int n)
        {
            var originalDigits = CountDigits(n);
            var originalSum = SumDigits(n);

            while(true){
                n++;
                var currentSum = SumDigits(n);
                if(originalSum == currentSum)
                {
                    var currentDigits = CountDigits(n);
                    if (CompareDigits(originalDigits, currentDigits))
                        break;
                }
            }
            return n;
        }
        static Dictionary<int, int> CountDigits(int n)
        {
            var absN = Math.Abs(n).ToString();
            var absNList = absN.ToCharArray().Select(p => (int)Char.GetNumericValue(p)).ToList();
            return absNList.GroupBy(p => p).Select(p => new {key = p.Key, sum = p.Count(k => true)}).ToDictionary(p => p.key, p=> p.sum);            
        }
        static int SumDigits(int n)
        {
            var absN = Math.Abs(n).ToString();
            var absNList = absN.ToCharArray().Select(p => (int)Char.GetNumericValue(p)).ToList();
            return absNList.GroupBy(p => true).Select(p => p.Sum(k => k)).FirstOrDefault();            
        }
        static bool CompareDigits(Dictionary<int, int> d1, Dictionary<int, int> d2)
        {
            d1.Remove(0);
            d2.Remove(0);
            if (d1.Count != d2.Count)
                return false;
            if (d1.Keys.Except(d2.Keys).Any())
                return false;
            if (d2.Keys.Except(d1.Keys).Any())
                return false;
            foreach (var pair in d1)
                if (pair.Value != d2[pair.Key])
                    return false;
            return true;
        }
    }    

}
