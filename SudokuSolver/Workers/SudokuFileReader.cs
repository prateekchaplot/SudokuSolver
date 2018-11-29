using System;
using System.IO;
using System.Linq;

namespace SudokuSolver.Workers
{
    class SudokuFileReader
    {
        public int[,] ReadFile(string filename)
        {
            int[,] sudokuBoard = new int[9, 9];

            try
            {
                var sudokuLines = File.ReadAllLines(filename);

                int row = 0;
                foreach (var sudokuLine in sudokuLines)
                {
                    string[] sudokuElements = sudokuLine.Split('|').Skip(1).Take(9).ToArray();

                    int col = 0;
                    foreach (var sudokuElement in sudokuElements)
                    {
                        sudokuBoard[row, col] = sudokuElement.Equals(" ") ? 0 : Convert.ToInt16(sudokuElement);
                        col++;
                    }

                    row++;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while reading the file: " + ex.Message);
            }

            return sudokuBoard;
        }
    }
}
