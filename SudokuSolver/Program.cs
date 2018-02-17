using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuSolver.Strategies;
using SudokuSolver.Workers;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SudokuBlockFinder sudokuBlockFinder = new SudokuBlockFinder();
                SudokuBoardStateManager sudokuBoardStateManager = new SudokuBoardStateManager();
                SudokuSolverEngine sudokuSolverEngine = new SudokuSolverEngine(sudokuBoardStateManager, sudokuBlockFinder);
                SudokuFileReader sudokuFileReader = new SudokuFileReader();
                SudokuDisplayer sudokuDisplayer = new SudokuDisplayer();

                Console.WriteLine("Enter the filename of the sudoku to solve");
                string filename = Console.ReadLine();
                var sudokuBoard = sudokuFileReader.ReadSudokuFile(filename);
                sudokuDisplayer.Display("Initial State", sudokuBoard);

                bool isSudokuSolved = sudokuSolverEngine.Solve(sudokuBoard);
                sudokuDisplayer.Display("Final State", sudokuBoard);

                //Final Message
                Console.WriteLine(isSudokuSolved 
                    ? "Great! You solved this sudoku puzzle"
                    : "Sorry, my algorithms need to be improved for solve this one!"
                    );

            } catch(Exception ex)
            {
                Console.WriteLine("{0}: {1}", "This Sudoku can not be solved. This is the error", ex.Message);
            }
        }
    }
}
