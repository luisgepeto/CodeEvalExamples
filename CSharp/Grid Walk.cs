using System;
using System.Collections.Generic;
using System.Linq;


namespace Grid_Walk
{
    class Program
    {
        public static int Grids { get; set; }
        static void Main(string[] args)
        {
            var myGridCell = new GridCell();

            GridCell.PreviouslyConsideredGridCellDictionary = new Dictionary<GridCell, bool>();
            GridCell.PreviouslyConsideredGridCellDictionary.Add(myGridCell, true);
            Grids = 1;
            RecursiveFunction(myGridCell);
            Console.WriteLine(Grids);
        }

        static void RecursiveFunction(GridCell currentGridCell)
        {
            var accesibleCells = currentGridCell.GetNeighbouringAccessibleGridCellList();
            if (accesibleCells.Count == 0)
            {
                return;
            }
            else
            {
                foreach (var nextGridCell in accesibleCells)
                {
                    Grids++;
                    RecursiveFunction(nextGridCell);
                }
                return;
            }
        }
        
    }
    enum Direction
    {
        Up,
        Down,
        Right,
        Left
    }    
    class GridCell
    {
        public int X { get; set; }
        public int Y { get; set; }   
        public static Dictionary<GridCell, bool> PreviouslyConsideredGridCellDictionary {get; set;}
        public GridCell(int x=0, int y=0)
        {
            X = x;
            Y = y;
        }
        private bool IsAccessible()
        {
            if (SumX() + SumY() < 20)
                return true;
            return false;
        }
        private bool HasBeenVisited()
        {
            if (PreviouslyConsideredGridCellDictionary.ContainsKey(this))
                return true;
            else
                PreviouslyConsideredGridCellDictionary.Add(this, true);
            return false; 
        }
        private int SumX()
        {
            return CalculateSum(X);
        }
        private int SumY()
        {
            return CalculateSum(Y);
        }

        private int CalculateSum(int n)
        {
            var absN = Math.Abs(n).ToString();
            var absNList = absN.ToCharArray().Select(p => (int)Char.GetNumericValue(p)).ToList();
            return absNList.GroupBy(p => true).Select(p => p.Sum(k => k)).FirstOrDefault();            
        }
        public List<GridCell> GetNeighbouringAccessibleGridCellList()
        {
            List<GridCell> accesibleCells = new List<GridCell>();
            var allNeighbouringGridCells = GetNeighbouringGridCellList();
            foreach (var gridCell in allNeighbouringGridCells)
            {
                if (gridCell.IsAccessible() && !gridCell.HasBeenVisited())
                {                    
                    accesibleCells.Add(gridCell);
                }   
            }
            return accesibleCells;
        }

        private List<GridCell> GetNeighbouringGridCellList()
        {
            List<GridCell> gridCellList = new List<GridCell>();
            var allDirections = Enum.GetValues(typeof(Direction)).Cast<Direction>();
            foreach (var direction in allDirections)
            {
                var currentGridCell = GetNeighbouringCell(direction);
                gridCellList.Add(currentGridCell);
            }
            return gridCellList;
        }
        private GridCell GetNeighbouringCell(Direction direction)
        {
            GridCell newGridCell = null;
            switch (direction)
            {
                case Direction.Up:
                    newGridCell = new GridCell(X, Y + 1);
                    break;
                case Direction.Down:
                    newGridCell = new GridCell(X, Y - 1);
                    break;
                case Direction.Right:
                    newGridCell = new GridCell(X+1, Y);
                    break;
                case Direction.Left:
                    newGridCell = new GridCell(X-1, Y);
                    break;
                default:
                    newGridCell = new GridCell(X, Y);
                    break;
            }
            return newGridCell;
        }

        public override int GetHashCode()
        {
            return X ^ Y;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            GridCell gc = obj as GridCell;
            if ((object)gc == null)
                return false;
            return (X == gc.X) && (Y == gc.Y);
        }
    }

    
}
