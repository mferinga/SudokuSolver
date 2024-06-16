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

        public bool KillerGuessCheck(int[] row, int[] col, int[] box, int[] cage, int[] cageOptions, int guess)
        {
            if (row.Contains(guess) || col.Contains(guess) || box.Contains(guess) || cage.Contains(guess))
            {
                return false;
            }

            if (!cageOptions.Contains(guess))
            {
                return false;
            }

            return true;
        }

        public List<int[]> CageOptions()
        {
            throw new NotImplementedException();
        }
    }
}
