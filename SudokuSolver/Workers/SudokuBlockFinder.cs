using SudokuSolver.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Workers
{
    class SudokuBlockFinder
    {
        public SudokuBlock Find (int row, int col)
        {
            SudokuBlock sudokuBlock = new SudokuBlock();
            
            //first col conditions
            if ((row >= 0 && row <= 2) && (col >= 0 && col <= 2)) { sudokuBlock.startRow = 0; sudokuBlock.startCol = 0; }
            else if ((row >= 3 && row <= 5) && (col >= 0 && col <= 2)) { sudokuBlock.startRow = 3; sudokuBlock.startCol = 0; }
            else if ((row >= 6 && row <= 8) && (col >= 0 && col <= 2)) { sudokuBlock.startRow = 6; sudokuBlock.startCol = 0; }

            //second col conditions
            else if ((row >= 0 && row <= 2) && (col >= 3 && col <= 5)) { sudokuBlock.startRow = 0; sudokuBlock.startCol = 3; }
            else if ((row >= 3 && row <= 5) && (col >= 3 && col <= 5)) { sudokuBlock.startRow = 3; sudokuBlock.startCol = 3; }
            else if ((row >= 6 && row <= 8) && (col >= 3 && col <= 5)) { sudokuBlock.startRow = 6; sudokuBlock.startCol = 3; }

            //third col cond itions
            else if ((row >= 0 && row <= 2) && (col >= 6 && col <= 8)) { sudokuBlock.startRow = 0; sudokuBlock.startCol = 6; }
            else if ((row >= 3 && row <= 5) && (col >= 6 && col <= 8)) { sudokuBlock.startRow = 3; sudokuBlock.startCol = 6; }
            else if ((row >= 6 && row <= 8) && (col >= 6 && col <= 8)) { sudokuBlock.startRow = 6; sudokuBlock.startCol = 6; }




            return sudokuBlock;
        }
    }
}
