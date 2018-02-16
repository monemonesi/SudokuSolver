using SudokuSolver.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Strategies
{
    class SudokuSolverEngine
    {
        private readonly SudokuBoardStateManager _sudokuBoardStateManager;
        private readonly SudokuBlockFinder _sudokuBlockFinder;

        public SudokuSolverEngine(SudokuBoardStateManager sudokuBoardStateManager, SudokuBlockFinder sudokuBlockFinder)
        {
            _sudokuBoardStateManager = sudokuBoardStateManager;
            _sudokuBlockFinder = sudokuBlockFinder;
        }

        public bool Solve(int[,] sudokuBoard)
        {
            List<ISudokuStrategy> implementedStrategies = new List<ISudokuStrategy>()
            {

            };

            var currentState = _sudokuBoardStateManager.GenerateState(sudokuBoard);

            var nextState = _sudokuBoardStateManager.GenerateState(implementedStrategies.First().Solve(sudokuBoard));

            while (!_sudokuBoardStateManager.isSolved(sudokuBoard) && currentState != nextState)
            {
                currentState = nextState;
                foreach (var strategy in implementedStrategies) nextState = _sudokuBoardStateManager.GenerateState(strategy.Solve(sudokuBoard));
            }


            return _sudokuBoardStateManager.isSolved(sudokuBoard);
        }

    }
}
