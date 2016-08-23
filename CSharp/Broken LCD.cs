using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broken_LCD
{
    class Program
    {
        static void Main(string[] args)
        {
            var segment = new Segment();
            var segment2 = new Segment("1");
            var segment3 = new Segment(1);
        }
    }
    class Display
    {
        public List<Segment> SegmentList { get; set; }

    }

    class Segment
    {
        public Segment() : this(1){}
        public Segment(string initializer) : this(Int32.Parse(initializer)){}
        public Segment(int initializer)
        {
            if (initializer == 0)
            {
                IsBroken = true;
            }
        }
        public bool IsBroken { get; set; }
        public BcdEquation MyProperty { get; set; }
    }

    class BcdEquation
    {
        public Dictionary<int, bool> ParametersDictionary { get; set; }
    }
}
