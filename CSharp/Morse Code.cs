using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morse_Code
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class MorseSymbol
    {
        public string MorseString { get; set; }
        public string String { get; set; }

        public string GetStringFromMorse()
        {

        }
    }

    class MorseDictionary
    {
        public Dictionary<string, string> MorseDictionary { get; set; }
        public MorseDictionary()
        {
            MorseDictionary = new Dictionary<string, string>();            
            MorseDictionary.Add(".-", "A");
            MorseDictionary.Add("-...", "B");
            MorseDictionary.Add("-.-.", "C");
            MorseDictionary.Add("-..", "D");
            MorseDictionary.Add(".", "E");
            MorseDictionary.Add("..-.", "F");
            MorseDictionary.Add("--.", "G");
            MorseDictionary.Add("....", "H");
            MorseDictionary.Add("..", "I");
            MorseDictionary.Add(".---", "J");
            MorseDictionary.Add("-.-", "K");
            MorseDictionary.Add(".-..", "L");
            MorseDictionary.Add("--", "M");
            MorseDictionary.Add("-.", "N");
            MorseDictionary.Add("---", "O");
            MorseDictionary.Add(".--.", "P");
            MorseDictionary.Add("", "Q");
            MorseDictionary.Add("", "R");
            MorseDictionary.Add("", "S");
            MorseDictionary.Add("", "T");
            MorseDictionary.Add("", "U");
            MorseDictionary.Add("", "V");
            MorseDictionary.Add("", "W");
            MorseDictionary.Add("", "X");
            MorseDictionary.Add("", "Y");
            MorseDictionary.Add("", "Z");

            MorseDictionary.Add("", "1");
            MorseDictionary.Add("", "2");
            MorseDictionary.Add("", "3");
            MorseDictionary.Add("", "4");
            MorseDictionary.Add("", "5");
            MorseDictionary.Add("", "6");
            MorseDictionary.Add("", "7");
            MorseDictionary.Add("", "8");
            MorseDictionary.Add("", "9");
            MorseDictionary.Add("", "0");
        }
    }
}
