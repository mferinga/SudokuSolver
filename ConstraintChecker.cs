namespace SudokuSolver
{
    public class ConstraintChecker
    {
        List<int> result = new List<int>();

        public bool GuessCheck(int[] row, int[] col, int[] box, int guess)
        {
            if(row.Contains(guess) ||  col.Contains(guess) || box.Contains(guess))
            {
                return false;
            }

            return true;
        }
    }
}
