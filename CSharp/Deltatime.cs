using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deltatime
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);
            foreach (var line in lines)
            {
                var parameters = GetParameters(line);
                parameters.CalculateDifference();
                Console.WriteLine(parameters.Difference.ToString(@"hh\:mm\:ss"));
            }
        }
        static Parameters GetParameters(string line)
        {
            var stringArray = line.Split(' ');
            return new Parameters()
            {
                StartDate = DateTime.Parse(stringArray[0]),
                EndDate = DateTime.Parse(stringArray[1]),
            };
        }
    }

    class Parameters
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan Difference{ get; set; }

        public void CalculateDifference()
        {
            if(EndDate > StartDate)
                Difference = EndDate - StartDate;
            else
                Difference = StartDate - EndDate;
        }
    }
}
