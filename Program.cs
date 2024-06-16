
using System.Diagnostics;

namespace SudokuSolver
{
    public class Program
    {
        public static void Main(String[] args)
        {
            KillerSudokuSolver classicSudoku = new KillerSudokuSolver();
            ConstraintChecker checker = new ConstraintChecker();
            Stopwatch stopwatch = new Stopwatch();

            int[][] grid;

            grid = classicSudoku.getGrid();
            Console.WriteLine("row 3, col 4 = " + grid[2][3]);

            classicSudoku.print();

            Console.WriteLine("\nSudoku Solution:");

            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine("Timer started at: " + DateTime.Now.ToString("HH:mm:ss.fff"));

            if (classicSudoku.ClassicSudokuSolver())
            {
                classicSudoku.print();
                stopwatch.Stop();
                Console.WriteLine("Time stopped at: " + DateTime.Now.ToString("HH:mm:ss.fff"));
            }
            else
            {
                Console.WriteLine("No solution was found");
            }

            Console.WriteLine("\n\n\n\nKiller Sudoku");

            KillerSudokuSolver killerSudoku = new KillerSudokuSolver();
            int[,] killerGrid;

            killerSudoku.GenerateKillerSudoku();
            killerGrid = killerSudoku.getKillerGrid();

            killerSudoku.printKiller();

            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine("Timer started at: " + DateTime.Now.ToString("HH:mm:ss.fff"));

            Console.WriteLine("\nKiller Sudoku Solution:");

            if (killerSudoku.SolveKillerSudoku())
            {
                killerSudoku.printKiller();
                stopwatch.Stop();
                Console.WriteLine("Time stopped at: " + DateTime.Now.ToString("HH:mm:ss.fff"));
            }
            else
            {
                Console.WriteLine("No solution was found");
            }


        }


    }
}
