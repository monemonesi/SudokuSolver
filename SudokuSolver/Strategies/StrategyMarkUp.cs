using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuSolver.Workers;

namespace SudokuSolver.Strategies
{
    class StrategyMarkUp : ISudokuStrategy
    {
        private readonly SudokuBlockFinder _sudokuBlockFinder;

        public StrategyMarkUp(SudokuBlockFinder sudokuBlockFinder)
        {
            _sudokuBlockFinder = sudokuBlockFinder;
        }

        public int[,] Solve(int[,] sudokuBoard)
        {
            for (int row = 0; row < sudokuBoard.GetLength(0); row++)
            {
                for (int col = 0; col < sudokuBoard.GetLength(1); col++)
                {
                    if (sudokuBoard[row, col] == 0 || sudokuBoard[row, col].ToString().Length > 1)
                    {
                        var possibilitiesInRowCol = GetPossibilitiesInrowCol(sudokuBoard, row, col);
                        var possibilitiesInBlock = GetPossibilitiesInBlock(sudokuBoard, row, col);

                        sudokuBoard[row, col] = GetPossibilitiesIntersection(possibilitiesInRowCol, possibilitiesInBlock);
                    }
                }
                
            }//End cells checker
            return sudokuBoard;
        }//End Solve method

        private int GetPossibilitiesInrowCol(int[,] sudokuBoard, int givenRow, int givenCol)
        {
            int[] possibilities = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int row = 0; row < 9; row++) if (isAlreadyValid(sudokuBoard[row, givenCol])) possibilities[sudokuBoard[row, givenCol] - 1] = 0;
            for (int col = 0; col < 9; col++) if (isAlreadyValid(sudokuBoard[givenRow, col])) possibilities[sudokuBoard[givenRow, col] - 1] = 0;

            return Convert.ToInt32(String.Join(string.Empty, from p in possibilities where p!=0 select p) );
            //return Convert.ToInt32(String.Join(String.Empty,possibilities.Select(p => p).Where(p => p!=0)));
        }

        private int GetPossibilitiesInBlock(int[,] sudokuBoard, int givenRow, int givenCol)
        {
            int[] possibilities = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var sudokuBlock = _sudokuBlockFinder.Find(givenRow, givenCol);

            for (int row = sudokuBlock.startRow ; row <= sudokuBlock.startRow + 2 ; row++)
            {
                for (int col = sudokuBlock.startCol ; col <= sudokuBlock.startCol + 2; col++)
                {
                    if(isAlreadyValid(sudokuBoard[row, col])) possibilities[sudokuBoard[row, col] - 1] = 0;
                }

            }//End cells checker
            return Convert.ToInt32(String.Join(string.Empty, from p in possibilities where p != 0 select p));
            //return Convert.ToInt32(String.Join(String.Empty,possibilities.Select(p => p).Where(p => p!=0)));
        }

        private int GetPossibilitiesIntersection(int possibilitiesInRowCol, int possibilitiesInBlock)
        {
            var possibilitiesInRowColToCharArray = possibilitiesInRowCol.ToString().ToCharArray();
            var possibilitiesInBlockToCharArray = possibilitiesInBlock.ToString().ToCharArray();

            var possibilitiesIntersections = possibilitiesInRowColToCharArray.Intersect(possibilitiesInBlockToCharArray);

            return Convert.ToInt32(String.Join(string.Empty, possibilitiesIntersections));
        }

        private bool isAlreadyValid(int cell)
        {
            return cell != 0 && cell.ToString().Length == 1;
        }
    }
}
