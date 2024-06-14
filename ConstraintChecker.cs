namespace SudokuSolver
{
    public class ConstraintChecker
    {
        List<int> result = new List<int>();

        public List<int> CheckAllConstraints(int[] row, int[] col, int[] box)
        {
            rowCheck(row);
            collumnCheck(col);
            boxCheck(box);

            return result;
        }

        private void rowCheck(int[] row)
        {
            for(int i  = 1; i <= 9; i++)
            {
                if (!row.Contains(i))
                {
                    result.Add(i);
                }
            }
        }
        private void collumnCheck(int[] col)
        {
            for (int i = 1; i <= 9; i++)
            {
                if (!col.Contains(i))
                {
                    result.Add(i);
                }
            }
        }
        private void boxCheck(int[] box)
        {
            for (int i = 1; i <= 9; i++)
            {
                if (!box.Contains(i))
                {
                    result.Add(i);
                }
            }
        }   


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
