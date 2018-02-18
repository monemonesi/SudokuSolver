using SudokuSolver.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Strategies
{
    class NakedPairsStrategy : ISudokuStrategy
    {
        private readonly SudokuBlockFinder _sudokuBlockFinder;

        public NakedPairsStrategy(SudokuBlockFinder sudokuBlockFinder) => _sudokuBlockFinder = sudokuBlockFinder;


        public int[,] Solve(int[,] sudokuBoard)
        {
            for (int row = 0; row < sudokuBoard.GetLength(0); row++)
            {
                for (int col = 0; col < sudokuBoard.GetLength(1); col++)
                {
                    if (sudokuBoard[row, col] == 0 || sudokuBoard[row, col].ToString().Length > 1)
                    {
                        EliminateNakedPairFromOtherCellInRow(sudokuBoard, row, col);
                        EliminateNakedPairFromOtherCellInCol(sudokuBoard, row, col);
                        EliminateNakedPairFromOtherCellInBlock(sudokuBoard, row, col);
                    }
                }

            }//End cells checker
            return sudokuBoard;
        }

        private void EliminateNakedPairFromOtherCellInRow(int[,] sudokuBoard, int givenRow, int givenCol)
        {
            if (!HasNakedPairInRow(sudokuBoard, givenRow, givenCol)) return;

            for (int col = 0; col < sudokuBoard.GetLength(1); col++)
            {
                if(sudokuBoard[givenRow, col] != sudokuBoard[givenRow, givenCol] && sudokuBoard[givenRow, col].ToString().Length > 1)
                {
                    RemoveNakedPair(sudokuBoard, sudokuBoard[givenRow, givenCol], givenRow, col);
                }
            }
        }

        private void RemoveNakedPair(int[,] sudokuBoard, int valuesToRemove, int removeFromRow, int removeFromCol)
        {
            var valuesToRemoveArray = valuesToRemove.ToString().ToCharArray();
            foreach (var valueToRemove in valuesToRemoveArray)
            {
                sudokuBoard[removeFromRow, removeFromCol] = 
                    Convert.ToInt32(sudokuBoard[removeFromRow, removeFromCol].ToString().Replace(valueToRemove.ToString(),string.Empty));
            }
        }

        private bool HasNakedPairInRow(int[,] sudokuBoard, int givenRow, int givenCol)
        {
            for (int col = 0; col < sudokuBoard.GetLength(1); col++)
            {
                if (givenCol != col && IsNakedPair(sudokuBoard[givenRow, col], sudokuBoard[givenRow, givenCol])) return true;
            }
            return false;
        }

        private void EliminateNakedPairFromOtherCellInCol(int[,] sudokuBoard, int givenRow, int givenCol)
        {
            if (!HasNakedPairInCol(sudokuBoard, givenRow, givenCol)) return;

            for (int row = 0; row < sudokuBoard.GetLength(0); row++)
            {
                if (sudokuBoard[row, givenCol] != sudokuBoard[givenRow, givenCol] && sudokuBoard[row, givenCol].ToString().Length > 1)
                {
                    RemoveNakedPair(sudokuBoard, sudokuBoard[givenRow, givenCol], row, givenCol);
                }
            }
        }

        private bool HasNakedPairInCol(int[,] sudokuBoard, int givenRow, int givenCol)
        {
            for (int row = 0; row < sudokuBoard.GetLength(0); row++)
            {
                if (givenRow != row && IsNakedPair(sudokuBoard[row, givenCol], sudokuBoard[givenRow, givenCol])) return true;
            }
            return false;
        }

        private void EliminateNakedPairFromOtherCellInBlock(int[,] sudokuBoard, int givenRow, int givenCol)
        {
            if(!HasNakedPairInBlock(sudokuBoard, givenRow, givenCol)) return;
            var sudokuBlock = _sudokuBlockFinder.Find(givenRow, givenCol);

            for (int row = sudokuBlock.startRow; row <= sudokuBlock.startRow + 2; row++)
            {
                for (int col = sudokuBlock.startCol; col <= sudokuBlock.startCol + 2; col++)
                {
                    if(sudokuBoard[row,col].ToString().Length > 1 && sudokuBoard[row,col] != sudokuBoard[givenRow, givenCol])
                    {
                        RemoveNakedPair(sudokuBoard, sudokuBoard[givenRow, givenCol], row, col);
                    }
                }

            }//End cells checker
        }

        private bool HasNakedPairInBlock(int[,] sudokuBoard, int givenRow, int givenCol)
        {
            for (int row = 0; row < sudokuBoard.GetLength(0); row++)
            {
                for (int col = 0; col < sudokuBoard.GetLength(1); col++)
                {
                    if (sudokuBoard[row, col] == 0 || sudokuBoard[row, col].ToString().Length > 1)
                    {
                        var sameElement = givenRow == row && givenCol == col;
                        var elementInTheSameBlock =
                            _sudokuBlockFinder.Find(givenRow, givenCol).startRow == _sudokuBlockFinder.Find(row, col).startRow &&
                            _sudokuBlockFinder.Find(givenRow, givenCol).startCol == _sudokuBlockFinder.Find(row, col).startCol;

                        if(!sameElement && elementInTheSameBlock && IsNakedPair(sudokuBoard[givenRow, givenCol], sudokuBoard[row, col])) return true;

                    }
                }
            }//End cells checker
            return false;
        }

        private bool IsNakedPair(int firstPair, int secondPair) => firstPair.ToString().Length == 2 && firstPair.Equals(secondPair);

    }
}
