using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SudokuSolver.Workers
{
    class SudokuFileReader
    {

        public int [,] ReadSudokuFile(string fileName)
        {
            int[,] sudokuBoard = new int[9, 9];
            try
            {
                var sudoKuBoardLines = File.ReadAllLines(fileName);

                int sudokuRow = 0;
                foreach (var sudokuBoardLine in sudoKuBoardLines)
                {
                    string[] sudokuBoardLineValues = sudokuBoardLine.Split('|').Skip(1).Take(9).ToArray();

                    int sudokuCol = 0;
                    foreach (var sudokuBoardLineValue in sudokuBoardLineValues)
                    {
                        sudokuBoard[sudokuRow, sudokuCol] = sudokuBoardLineValue.Equals(" ") ? 0 : Convert.ToInt16(sudokuBoardLineValue);
                        sudokuCol++;
                    }//End sudokuCol

                    sudokuRow++;
                }//End sudokuRow
                

            }
            catch(Exception ex)
            {
                throw new Exception("Something is wrong with the file name " + ex.Message);
            }

            return sudokuBoard;
        }

    }
}
