using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephone_Words
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);
            foreach (var line in lines)
            {                
                var firstPhone = new Telephone(line);
                var completeTelephones = new List<string>();
                completeTelephones = RecursiveMethod(firstPhone, 0, completeTelephones);
                completeTelephones.Sort();
                var count = completeTelephones.Count;
                for (int i = 0; i < count; i++)
                {
                    Console.Write(completeTelephones.ElementAt(i));
                    if (i != count - 1)
                        Console.Write(",");
                    else
                        Console.WriteLine("");
                }
            }
        }
        static List<string> RecursiveMethod(Telephone currentTelephone, int position, List<string> completeTelephones)
        {
            var newTelephones = currentTelephone.ChangeChar(position);            
            if(newTelephones.Count ==0)
            {
                completeTelephones.Add(currentTelephone.Number);
                return completeTelephones;
            }
            else
            {
                position++;
                foreach(var newTelephone in newTelephones)
                {                    
                    RecursiveMethod(newTelephone, position, completeTelephones);
                }
                return completeTelephones;
            }
        }
    }
    class Telephone
    {
        public string Number { get; set; }
        public Telephone(string number)
        {
            Number = number;
        }

        public List<Telephone> ChangeChar(int position)
        {
            var numberArray = Number.ToCharArray();
            var numberList = new List<Telephone>();
            if(position == numberArray.Length){
                return numberList;
            }
            var currentChar = numberArray[position].ToString();
            switch (currentChar)
            {
                case "2":
                    numberArray[position] = 'a';
                    numberList.Add(new Telephone(new string(numberArray)));
                    numberArray[position] = 'b';
                    numberList.Add(new Telephone(new string(numberArray)));
                    numberArray[position] = 'c';
                    numberList.Add(new Telephone(new string(numberArray)));
                    break;
                case "3":
                    numberArray[position] = 'd';
                    numberList.Add(new Telephone(new string(numberArray)));
                    numberArray[position] = 'e';
                    numberList.Add(new Telephone(new string(numberArray)));
                    numberArray[position] = 'f';
                    numberList.Add(new Telephone(new string(numberArray)));
                    break;
                case "4":
                    numberArray[position] = 'g';
                    numberList.Add(new Telephone(new string(numberArray)));
                    numberArray[position] = 'h';
                    numberList.Add(new Telephone(new string(numberArray)));
                    numberArray[position] = 'i';
                    numberList.Add(new Telephone(new string(numberArray)));
                    break;
                case "5":
                    numberArray[position] = 'j';
                    numberList.Add(new Telephone(new string(numberArray)));
                    numberArray[position] = 'k';
                    numberList.Add(new Telephone(new string(numberArray)));
                    numberArray[position] = 'l';
                    numberList.Add(new Telephone(new string(numberArray)));
                    break;
                case "6":
                    numberArray[position] = 'm';
                    numberList.Add(new Telephone(new string(numberArray)));
                    numberArray[position] = 'n';
                    numberList.Add(new Telephone(new string(numberArray)));
                    numberArray[position] = 'o';
                    numberList.Add(new Telephone(new string(numberArray)));
                    break;
                case "7":
                    numberArray[position] = 'p';
                    numberList.Add(new Telephone(new string(numberArray)));
                    numberArray[position] = 'q';
                    numberList.Add(new Telephone(new string(numberArray)));
                    numberArray[position] = 'r';
                    numberList.Add(new Telephone(new string(numberArray)));
                    numberArray[position] = 's';
                    numberList.Add(new Telephone(new string(numberArray)));
                    break;
                case "8":
                    numberArray[position] = 't';
                    numberList.Add(new Telephone(new string(numberArray)));
                    numberArray[position] = 'u';
                    numberList.Add(new Telephone(new string(numberArray)));
                    numberArray[position] = 'v';
                    numberList.Add(new Telephone(new string(numberArray)));                    
                    break;
                case "9":
                    numberArray[position] = 'w';
                    numberList.Add(new Telephone(new string(numberArray)));
                    numberArray[position] = 'x';
                    numberList.Add(new Telephone(new string(numberArray)));
                    numberArray[position] = 'y';
                    numberList.Add(new Telephone(new string(numberArray)));
                    numberArray[position] = 'z';
                    numberList.Add(new Telephone(new string(numberArray)));
                    break;
                case "0":
                case "1":
                default:
                    numberList.Add(new Telephone(new string(numberArray)));
                    break;
            }  
            return numberList;
        }
    }
}
