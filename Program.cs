
namespace SudokuSolver
{
    public class Program
    {
        public static void Main(String[] args)
        {
            ClassicSudokuSover classicSudoku = new ClassicSudokuSover();
            ConstraintChecker checker = new ConstraintChecker();

            int[][] grid;

            grid = classicSudoku.getGrid();
            Console.WriteLine("row 3, col 4 = " + grid[2][3]);

        }


    }
}
