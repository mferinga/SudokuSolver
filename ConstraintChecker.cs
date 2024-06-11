namespace SudokuSolver
{
    public class ConstraintChecker
    {

        public bool rowCheck(int[] row, int guess)
        {
            if (row.Contains(guess))
            {
                return false;
            }

            return true;
        }

        public bool collumnCheck(int[] col, int guess)
        {
            if(col.Contains(guess))
            {
                return false;
            }

            return true;
        }

        public bool boxCheck(int[,] board, int row, int col, int guess)
        {
            return false;
        }   
    }
}
