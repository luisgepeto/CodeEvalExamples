using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AromaticNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);
            foreach (var line in lines)
            {
                var previousPair = new AromaticPair();
                var sum =0;
                for (var i = 0; i < line.Length; i += 2)
                {
                    var currentPair = new AromaticPair(line.Substring(i, 2));
                    if (previousPair.IsLessThanAromaticPair(currentPair))
                        sum -= previousPair.GetValue();
                    else
                        sum += previousPair.GetValue();
                    previousPair = currentPair;
                }
                sum += previousPair.GetValue();
                Console.WriteLine(sum);
            }
        }
    }
    class AromaticPair
    {
        public int ArabicNumeral { get; set; }
        public string RomanNumeral { get; set; }

        public AromaticPair()
        {
            ArabicNumeral = 0;
            RomanNumeral = "I";
        }
        public AromaticPair(string ar)
        {
            if (ar.Length == 2)
            {
                var letters = ar.ToCharArray();
                ArabicNumeral = Int32.Parse(letters[0]+"");
                RomanNumeral = "" + letters[1];
            }
        }
        public AromaticPair(int a, string r)
        {
            ArabicNumeral = a;
            RomanNumeral = r;
        }

        public int GetValue()
        {
            return ConvertFromRoman(RomanNumeral) * ArabicNumeral;
        }

        public bool IsLessThanAromaticPair(AromaticPair pair)
        {
            return (ConvertFromRoman(RomanNumeral) < ConvertFromRoman(pair.RomanNumeral));                
        }
        private static int ConvertFromRoman(string r)
        {
            var value = 0;
            switch (r)
            {
                case "I":
                    value= 1;
                    break;
                case "V":
                    value= 5;
                    break;
                case "X":
                    value= 10;
                    break;
                case "L":
                    value= 50;
                    break;
                case "C":
                    value= 100;
                    break;
                case "D":
                    value= 500;
                    break;
                case "M":
                    value= 1000;
                    break;
                default:
                    value = 0;
                    break;
            }
            return value;
        }
    }
}
