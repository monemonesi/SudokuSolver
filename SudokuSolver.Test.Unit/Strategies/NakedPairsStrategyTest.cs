using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver.Strategies;
using SudokuSolver.Workers;

namespace SudokuSolver.Test.Unit.Strategies
{
    [TestClass]
    public class NakedPairsStrategyTest
    {
        private readonly NakedPairsStrategy _nakedPairsStrategy = new NakedPairsStrategy(new SudokuBlockFinder());

        [TestMethod]
        public void ShouldEiminateNakedPairNumbersOnRow()
        {
            //4
            int[,] sudokuBoard =
            {
                {1,23,4,5,23,7,236,9,8},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0}

            };

            var solvedSudokuBoard = _nakedPairsStrategy.Solve(sudokuBoard);

            Assert.IsTrue(solvedSudokuBoard[0, 6] == 6);
        }

        [TestMethod]
        public void ShouldEiminateNakedPairNumbersOnCol()
        {
            //4
            int[,] sudokuBoard =
            {
                {1,0,0,0,0,0,0,0,0},
                {23,0,0,0,0,0,0,0,0},
                {4,0,0,0,0,0,0,0,0},
                {5,0,0,0,0,0,0,0,0},
                {23,0,0,0,0,0,0,0,0},
                {7,0,0,0,0,0,0,0,0},
                {236,0,0,0,0,0,0,0,0},
                {9,0,0,0,0,0,0,0,0},
                {8,0,0,0,0,0,0,0,0},

            };

            var solvedSudokuBoard = _nakedPairsStrategy.Solve(sudokuBoard);

            Assert.IsTrue(solvedSudokuBoard[6, 0] == 6);
        }

        [TestMethod]
        public void ShouldEiminateNakedPairNumbersOnBlock()
        {
            //4
            int[,] sudokuBoard =
            {
                {1,23,4,0,0,0,0,0,0},
                {5,23,7,0,0,0,0,0,0},
                {236,9,8,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0}

            };

            var solvedSudokuBoard = _nakedPairsStrategy.Solve(sudokuBoard);

            Assert.IsTrue(solvedSudokuBoard[2, 0] == 6);
        }

        [TestMethod]
        public void ShouldEiminateNakedPairNumbersOnBlock6()
        {
            //4
            int[,] sudokuBoard =
            {
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,1,23,4},
                {0,0,0,0,0,0,5,23,7},
                {0,0,0,0,0,0,236,9,8},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0}

            };

            var solvedSudokuBoard = _nakedPairsStrategy.Solve(sudokuBoard);

            Assert.IsTrue(solvedSudokuBoard[5, 6] == 6);
        }

        [TestMethod]
        public void ShouldEiminateNakedPairNumbersOnBlock9()
        {
            //4
            int[,] sudokuBoard =
            {
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,1,2,34},
                {0,0,0,0,0,0,34,5,6},
                {0,0,0,0,0,0,347,8,9}

            };

            var solvedSudokuBoard = _nakedPairsStrategy.Solve(sudokuBoard);

            Assert.IsTrue(solvedSudokuBoard[8, 6] == 7);
        }
    }
}