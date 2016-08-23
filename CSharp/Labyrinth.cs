using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    class Program
    {
        static void Main(string[] args)
        { 
            string[] lines = System.IO.File.ReadAllLines(args[0]);
            
            var yDimension = lines.Length;
            var xDimension = lines[yDimension - 1].Length;
            
            var labyrinth = new Labyrinth(xDimension, yDimension);
            labyrinth.Squares = CreateSquares(xDimension, yDimension, lines);
            labyrinth.InitializeLabyrinth();
            List<Square> steps = new List<Square>();
            steps = FindExit(labyrinth, labyrinth.Entrance, steps);
            steps.Add(labyrinth.Entrance);
            PrintLabyrinth(labyrinth, steps);            
        }

        public static void PrintLabyrinth(Labyrinth labyrinth, List<Square> steps)
        {
            var allSquares = labyrinth.Squares.OrderBy(s => s.Y).ThenBy(s => s.X);
            foreach (var currentSquare in allSquares)
            {
                if (currentSquare.IsWall)
                    Console.Write('*');
                else if (steps.Contains(currentSquare))
                    Console.Write('+');
                else
                    Console.Write(' ');
                if(currentSquare.X == labyrinth.XSize-1)
                    Console.WriteLine("");
            }
        }
        static List<Square> FindExit(Labyrinth labyrinth, Square currentSquare, List<Square> steps)
        {
            var accessibleSquares = labyrinth.GetNeighbouringAccesibleSquares(currentSquare);
            if (accessibleSquares.Any(s => labyrinth.IsExit(s)))
            {
                steps.Add(accessibleSquares.Where(s => labyrinth.IsExit(s)).FirstOrDefault());
                return steps;
            }
            else
            {
                var list = new List<Square>();
                foreach (var nextSquare in accessibleSquares)
                {   
                    list = FindExit(labyrinth, nextSquare, steps);
                    if (list.Any())
                    {
                        steps.Add(nextSquare);
                        break;
                    }
                }   
                return steps;
            }            
        }
 
        private static List<Square> CreateSquares(int xDimension, int yDimension, string[] lines)
        {
            var squares = new List<Square>();
            for (var j = 0; j < yDimension; j++)
            {                
                var currentBricks = lines[j].ToCharArray();
                
                for (var i = 0; i < xDimension; i++)
                {
                    Square square = CreateSquare(i, j, currentBricks[i]);
                    squares.Add(square);
                }
            }
            return squares;
        }
 
        private static Square CreateSquare(int i, int j, char brick)
        {
            Square square = new Square(i, j);            
            if (brick == '*')
            {
                square.IsWall = true;
            }
            else
            {
                square.IsWall = false;
            }
            return square;
        }
    }

    class Labyrinth
    {
        public int XSize{ get; set; }
        public int YSize { get; set; }
        public List<Square> Squares{ get; set; }
        private List<Square> OpeningsAlongWall{ get; set; }
        public Square Entrance { get; set; }
        public Square Exit { get; set; }
        
        public Labyrinth(int x, int y)
        {
            XSize = x;
            YSize = y;           
        }

        public void InitializeLabyrinth()
        {
            FindOpeningsAlongWall();
            if (OpeningsAlongWall.Count == 2)
            {
                FindEntrance();
                FindExit();
                Square.PreviouslyConsideredSquare = new Dictionary<Square, bool>();
                Square.PreviouslyConsideredSquare.Add(Entrance, true);
            }
        }
        private void FindEntrance()
        {
            Entrance = OpeningsAlongWall.ElementAt(0);
        }

        private void FindExit()
        {
            Exit = OpeningsAlongWall.ElementAt(1);
        }
        public bool IsExit(Square square)
        {
            return square.Equals(Exit);
        }
        private void FindOpeningsAlongWall()
        {
            List<Square> openingList = new List<Square>();
            foreach (var square in Squares)
            {
                if (!square.IsWall && ((square.X == 0 || square.X == XSize - 1) || (square.Y == 0 || square.Y == YSize - 1)))
                    openingList.Add(square);
                if (openingList.Count == 2)
                    break;
            }
            OpeningsAlongWall = openingList;
        }
        public List<Square> GetNeighbouringAccesibleSquares(Square square)
        {
            List<Square> squareList  = new List<Square>();
            var allDirections = Enum.GetValues(typeof(Direction)).Cast<Direction>();
            foreach (var direction in allDirections)
            {
                var currentSquare = GetNeighbouringSquare(square, direction);
                if(currentSquare != null && currentSquare.IsValid() && !currentSquare.HasBeenVisited())
                    squareList.Add(currentSquare);
            }
            return squareList;
        }
        
        public  Square GetNeighbouringSquare(Square square, Direction direction)
        {
            Square newSquare = null;
            switch (direction)
            {
                case Direction.Up:
                    newSquare = Squares.Where(s => s.X == square.X && s.Y == square.Y + 1).FirstOrDefault();
                    break;
                case Direction.Down:
                    newSquare = Squares.Where(s => s.X == square.X && s.Y == square.Y - 1).FirstOrDefault();
                    break;
                case Direction.Right:
                    newSquare = Squares.Where(s => s.X == square.X+1 && s.Y == square.Y).FirstOrDefault();
                    break;
                case Direction.Left:
                    newSquare = Squares.Where(s => s.X == square.X-1 && s.Y == square.Y).FirstOrDefault();
                    break;
                default:
                    newSquare = null;
                    break;
            }
            return newSquare;
        }
    }
    class Square
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsWall { get; set; }
        public static Dictionary<Square, bool> PreviouslyConsideredSquare {get; set;}
        public Square(int x,int y)
        {
            X = x;
            Y = y;
        }        
        public bool IsValid()
        {
            return (X >= 0 && Y >= 0 && !IsWall);
        }
        public bool HasBeenVisited()
        {
            if (PreviouslyConsideredSquare == null)
            {
                PreviouslyConsideredSquare = new Dictionary<Square, bool>();
            }
            if (PreviouslyConsideredSquare.ContainsKey(this))
                return true;
            else
                PreviouslyConsideredSquare.Add(this, true);
            return false; 
        }        
        
        
        public override int GetHashCode()
        {
            return X ^ Y;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Square sq = obj as Square;
            if ((object)sq == null)
                return false;
            return (X == sq.X) && (Y == sq.Y);
        }
    }
    enum Direction
    {
        Up,
        Down,
        Right,
        Left
    }
}
