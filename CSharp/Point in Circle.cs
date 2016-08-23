using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_in_Circle
{
    class Program
    {
        static void Main(string[] args)
        {
           string[] lines = System.IO.File.ReadAllLines(args[0]);
           foreach (var line in lines)
           {
               var parameters = GetParameters(line);
               var circle = parameters.GetCircle();
               var point = parameters.GetPoint();
               if (circle.IsInsideCircle(point))
                   Console.WriteLine("true");
               else
                   Console.WriteLine("false");
           }
        }

        static Parameters GetParameters(string line)
        {
            var groups = line.Split(';');
            var formattedGroups = new List<string>();
            foreach (var group in groups)
            {   
                formattedGroups.Add(group.Split(':').Last().Trim());
            }
            return new Parameters()
            {
                CenterCoords = formattedGroups.ElementAt(0),
                RadiusVal = formattedGroups.ElementAt(1),
                PointCoords = formattedGroups.ElementAt(2),
            };
        }
        
    }
    class Parameters
    {
        public string CenterCoords { get; set; }
        public string RadiusVal { get; set; }
        public string PointCoords { get; set; }
        public Circle GetCircle()
        {
            var center = GetCenter();
            var radius = Double.Parse(RadiusVal);
            return new Circle(center, radius);
        }
        private  Point GetCenter()
        {
            var coordList = GetCoordList(CenterCoords);
            return new Point(coordList);
        }
        public Point GetPoint()
        {
            var coordList = GetCoordList(PointCoords);
            return new Point(coordList);
        }
        
        private List<double> GetCoordList(string coordinate)
        {
            return coordinate.Trim('(').Trim(')').Split(',').Select(a => Double.Parse(a)).ToList();
        }        
    }
    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public Point (List<double> coordList)
        {
            X = coordList.ElementAt(0);
            Y = coordList.ElementAt(1);
        }
    }
    class Circle
    {
        public Point Center { get; set; }
        public double Radius { get; set; }
        public Circle(Point center, double radius)
        {
            Center = center;
            Radius = radius;
        }
        public bool IsInsideCircle(Point point)
        {
            return Math.Pow(point.X - Center.X, 2) + Math.Pow(point.Y - Center.Y, 2) <= Math.Pow(Radius, 2);
        }
    }
}
