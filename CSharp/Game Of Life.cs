using System;
using System.Collections.Generic;
using System.Linq;

namespace Game_Of_Life
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);
            var sideSize = lines.Length;

            var grid = new Grid(sideSize);
            grid.InitializeGrid(lines);
            
            for (var i = 0; i < 10; i++)
            {
                grid.UpdateCellStatus();                
            }
            grid.PrintGrid();
        }
    }

    class Grid
    {
        public int SideSize { get; set; }
        public List<Cell> CellList{ get; set; }
        public Dictionary<Cell, bool> CellStatusDict { get; set; }
        public Grid(int sideSize)
        {
            SideSize = sideSize;
            CellStatusDict = new Dictionary<Cell, bool>();
        }

        public void PrintGrid()
        {
            var orderedCells = CellStatusDict.OrderBy(c => c.Key.Y).ThenBy(c => c.Key.X);
            foreach (var cell in orderedCells)
            {
                if (cell.Value)
                    Console.Write('*');
                else
                    Console.Write('.');
                if(cell.Key.X == SideSize-1)
                    Console.WriteLine("");
            }
        }
        public void InitializeGrid(string[] lines)
        {
            for (var i = 0; i < SideSize; i++)
            {
                var currentLine = lines[i].ToCharArray();
                for (var j = 0; j < SideSize; j++)
                {
                    var newCell = new Cell(j, i);
                    if (currentLine[j] == '*')
                        newCell.IsAlive = true;
                    else
                        newCell.IsAlive = false;
                    CellStatusDict.Add(newCell, newCell.IsAlive);
                }
            }
        }

        public void UpdateCellStatus()
        {
            CellStatusDict = GetNewCellListStatus();
        }
        private  Dictionary<Cell, bool> GetNewCellListStatus()
        {
            var newStatus = new  Dictionary<Cell, bool>();
            foreach (var cell in CellStatusDict)
            {
                var newCell = GetNewCellStatus(cell.Key);
                newStatus.Add(newCell, newCell.IsAlive);
            }
            return newStatus;
        }

        private Cell GetNewCellStatus(Cell cell)
        {
            var newCell = new Cell(cell.X, cell.Y, cell.IsAlive);
            
            var aliveCellCount = CountAliveNeighbouringCells(cell);
            if (cell.IsAlive)
            {
                if (aliveCellCount < 2 || aliveCellCount > 3)
                    newCell.IsAlive = false;                        
            }
            else
            {
                if (aliveCellCount == 3)
                    newCell.IsAlive = true;
            }
            return newCell;
        }
        private int CountAliveNeighbouringCells(Cell cell)
        {
            var neighboringCellCount = 0;
            var allDirections = Enum.GetValues(typeof(Direction)).Cast<Direction>();
            foreach(var direction in allDirections)
            {
                var isAlive = IsNeighboringCellAlive(cell, direction);
                if(isAlive)
                    neighboringCellCount++;
                if (neighboringCellCount > 3)
                    break;
            }
            return neighboringCellCount;
        }

        
        private bool IsNeighboringCellAlive(Cell cell, Direction direction)
        {
            bool isAlive = false;
            switch (direction)
            {
                case Direction.Up:
                    CellStatusDict.TryGetValue(new Cell(cell.X, cell.Y - 1), out isAlive);
                        //CellList.Where(c => c.X == cell.X && c.Y == cell.Y - 1).FirstOrDefault();
                    break;
                case Direction.Down:
                    CellStatusDict.TryGetValue(new Cell(cell.X, cell.Y + 1), out isAlive);
                        //CellList.Where(c => c.X == cell.X && c.Y == cell.Y + 1).FirstOrDefault();
                    break;
                case Direction.Right:
                    CellStatusDict.TryGetValue(new Cell(cell.X+1, cell.Y), out isAlive);
                        //CellList.Where(c => c.X == cell.X+1 && c.Y == cell.Y).FirstOrDefault();
                    break;
                case Direction.Left:
                    CellStatusDict.TryGetValue(new Cell(cell.X-1, cell.Y), out isAlive);
                        //CellList.Where(c => c.X == cell.X-1 && c.Y == cell.Y).FirstOrDefault();
                    break;
                case Direction.UpRight:
                    CellStatusDict.TryGetValue(new Cell(cell.X+1, cell.Y - 1), out isAlive);
                        //CellList.Where(c => c.X == cell.X+1 && c.Y == cell.Y - 1).FirstOrDefault();
                    break;
                case Direction.UpLeft:
                    CellStatusDict.TryGetValue(new Cell(cell.X-1, cell.Y - 1), out isAlive);
                        //CellList.Where(c => c.X == cell.X-1 && c.Y == cell.Y - 1).FirstOrDefault();
                    break;
                case Direction.DownRight:
                    CellStatusDict.TryGetValue(new Cell(cell.X+1, cell.Y + 1), out isAlive);
                        //CellList.Where(c => c.X == cell.X+1 && c.Y == cell.Y+1).FirstOrDefault();
                    break;
                case Direction.DownLeft:
                    CellStatusDict.TryGetValue(new Cell(cell.X-1, cell.Y + 1), out isAlive);
                        // CellList.Where(c => c.X == cell.X-1 && c.Y == cell.Y+1).FirstOrDefault();
                    break;
                default:
                    isAlive = false;
                    break;
            }
            return isAlive;
        }
    }
    class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsAlive { get; set;}
        public Cell(int x,int y){
            X = x;
            Y = y;
        }
        public Cell(int x,int y, bool isAlive){
            X = x;
            Y = y;
            IsAlive = isAlive;
        }
        public override int GetHashCode()
        {
            return X ^ Y;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Cell c = obj as Cell;
            if ((object)c == null)
                return false;
            return (X == c.X) && (Y == c.Y);
        }
    }
    enum Direction
    {
        Up, 
        Right,
        Down,
        Left,
        UpRight,
        UpLeft,
        DownRight,
        DownLeft
    }
}
