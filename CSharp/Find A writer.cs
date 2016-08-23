using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_A_writer
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);
            foreach (var line in lines)
            {
                var code = GetCode(line);
                code.GetDecypheredMessage();
                code.PrintDecypheredMessage();
            }
        }

        static Code GetCode(string line)
        {
            return new Code()
            {
                CypheredMessage = line.Split('|').ElementAt(0),
                Indexes = line.Split('|').Last().Split(' ').Where(a => !String.IsNullOrEmpty(a+"")).Select(a => Int32.Parse(a)).ToList()
            };
        }
    }
    class Code
    {
        public string CypheredMessage { get; set; }
        public List<char> DecypheredMessage { get; set; }
        public List<int> Indexes { get; set; }

        public void GetDecypheredMessage()
        {
            List<char> outputMessage = new List<char>();
            foreach (var index in Indexes)
            {
                outputMessage.Add(CypheredMessage.ElementAt(index - 1));
            }
            DecypheredMessage =  outputMessage;
        }

        public void PrintDecypheredMessage()
        {
            foreach (var letter in DecypheredMessage)
            {
                Console.Write(letter);
            }
            Console.WriteLine("");
        }
    }
}
