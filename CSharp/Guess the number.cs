using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guess_the_number
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);            
            foreach (string line in lines)
            {
                var parameters = GetParameters(line);
                var answer = GetAnswer(parameters);
                Console.WriteLine(answer);
            }
        }

        public static int GetAnswer(Parameters parameters){
            var guess =0;
            foreach(var command in parameters.Commands){
                guess = parameters.GetGuess();
                parameters.ChangeLimit(guess, command);
            }
            return guess;
        }
        public static Parameters GetParameters(string line)
        {
            var words = line.Split(' ');
            
            var parameters = new Parameters();
            parameters.MinLimit = 0;
            parameters.MaxLimit = Int32.Parse(words.ElementAt(0));
            parameters.Commands = words.Skip(1).ToList();            
            return parameters;
        }
    }

    class Parameters
    {
        public int MinLimit { get; set; }
        public int MaxLimit { get; set; }
        public List<string> Commands { get; set; }

        public int GetGuess(){
            return (int)Math.Ceiling((MaxLimit - MinLimit)/2.0) +MinLimit;
        }

        public void ChangeLimit(int guess, string command){
            if (command == "Lower")
                MaxLimit = guess - 1;
            else if (command == "Higher")
                MinLimit = guess + 1;
            else
                return;
        }
    }    
}
