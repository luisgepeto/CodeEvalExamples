using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);
            foreach (var line in lines)
            {
                var parameters = GetParameters(line);
                var sudoku = new Sudoku(parameters.Size, parameters.Numbers);
                if (sudoku.IsValid)
                    Console.WriteLine("True");
                else
                    Console.WriteLine("False");
            }
        }

        static Parameters GetParameters(string line)
        {
            var separatedSize = line.Split(';');
            var parameters = new Parameters();
            parameters.Size = Int32.Parse(separatedSize[0]);
            parameters.Numbers = separatedSize[1].Split(',').Select(l => Int32.Parse(l)).ToList();
            return parameters;
        }
    }
    class Parameters
    {
        public int Size { get; set; }
        public List<int> Numbers { get; set; }
    }

    class Sudoku
    {
        public Dictionary<int, SudokuBrick> RowDictionary { get; set; }
        public Dictionary<int, SudokuBrick> ColumnDictionary { get; set; }
        public Dictionary<int, SudokuBrick> SquareDictionary { get; set; }
        public int Size { get; set; }
        public List<SudokuBrick> BrickList { get; set; }

        public bool IsValid { get; set; }        

        public Sudoku(int size, List<int> numberList)
        { 
            Size = size;
            CreateBrickDictionaries();            
            IsValid = IsSudokuValid(numberList);
        }
 
        private bool IsSudokuValid(List<int> numberList)
        {
            var i = 0;
            var j = 0;
            var k = 0;            
            while (!(j == Size && i == Size-1))
            { 
                UpdateIndexes(ref i, ref j, ref k);

                var currentRow = RowDictionary[i];
                var currentColumn = ColumnDictionary[j];
                var currentSquare = SquareDictionary[k];

                int currentElement = numberList.ElementAt(Size*i + j);
                var isNotRepeated = AddCurrentElement(currentElement, currentRow, currentColumn, currentSquare);
                if (isNotRepeated)
                {
                    j++;
                }
                else
                {
                    return false;
                }                
            }
            return true;
        }
 
        private bool AddCurrentElement(int currentElement, SudokuBrick currentRow, SudokuBrick currentColumn, SudokuBrick currentSquare)
        {
            var validRow = currentRow.AddNumber(currentElement);                
            if (validRow)
            {
                var validColumn = currentColumn.AddNumber(currentElement);
                if (validColumn)
                {
                    var validSquare = currentSquare.AddNumber(currentElement);
                    if (validSquare)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
 
        private void UpdateIndexes(ref int i, ref int j,ref int k)
        {
            if (j % (int)Math.Sqrt(Size) == 0 && j != 0)
            {
                k++;
            }
            if (j % Size == 0 && j != 0)
            {
                j = 0;
                k -= (int)Math.Sqrt(Size);
                i++;
            }
            if (i % (int)Math.Sqrt(Size) == 0 && i != 0 && j == 0)
            {
                k += (int)Math.Sqrt(Size);
            }
        }
 
        private void CreateBrickDictionaries()
        {
            InstantiateBrickDictionaries();            
            InitializeBrickDictionaries();
        }
        private void InstantiateBrickDictionaries()
        {
            RowDictionary = new Dictionary<int, SudokuBrick>();
            ColumnDictionary = new Dictionary<int, SudokuBrick>();
            SquareDictionary = new Dictionary<int, SudokuBrick>();
        }
        private void InitializeBrickDictionaries()
        {
            for (var l = 0; l < Size; l++)
            {
                RowDictionary.Add(l, new SudokuBrick());
                ColumnDictionary.Add(l, new SudokuBrick());
                SquareDictionary.Add(l, new SudokuBrick());
            }
        }        
    }

    class SudokuBrick
    {
        public int Size { get; set; }
        public List<int> Numbers { get; set; }

        public bool IsValid { get; set; }
        public bool AddNumber(int number)
        {
            if (!Numbers.Contains(number))
            {
                Numbers.Add(number);
            }
            else
            {
                IsValid = false;
            }
            return IsValid;
        }

        public SudokuBrick()
        {
            IsValid = true;
            Numbers = new List<int>();
        }
    }
}
