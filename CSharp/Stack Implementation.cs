using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Implementation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);
            foreach (var line in lines)
            {
                var numbers = line.Split(' ').Select(n => Int32.Parse(n)).ToList();
                Stack myStack = new Stack();
                foreach(var number in numbers){
                    myStack.Push(number);
                }
                var stringOut = "";
                var totalLength = myStack.StackIn.Count;
                for(var i=0; i< totalLength; i++){
                    var currentElement = myStack.Pop();
                    if (i % 2 == 0)
                        stringOut += currentElement + " ";
                }
                Console.WriteLine(stringOut.Trim());
            }
            
        }
    }

    class Stack
    {
        public Stack(){
            StackIn = new List<int>();
        }
        public List<int> StackIn { get; set;}        
        public void Push(int element){
            StackIn.Add(element);
        }
        public string Pop(){
            var outStack = "";
            if(StackIn != null && StackIn.Count > 0){
                outStack += StackIn.Skip(StackIn.Count-1).Take(1).FirstOrDefault();
                StackIn = StackIn.Take(StackIn.Count-1).ToList();
            }
            return outStack;
        }
    }
}
