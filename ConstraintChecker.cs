namespace SudokuSolver
{
    public class ConstraintChecker
    {

        public List<int> rowCheck(int[] row)
        {
            List<int> result = new List<int>();
            for(int i  = 1; i <= 9; i++)
            {
                if (!row.Contains(i))
                {
                    result.Add(i);
                }
            }
            return result;
        }

        public List<int> collumnCheck(int[] col)
        {
            List<int> result = new List<int>();
            for (int i = 1; i <= 9; i++)
            {
                if (!col.Contains(i))
                {
                    result.Add(i);
                }
            }
            return result;
        }

        public List<int> boxCheck(int[][] box)
        {
            List<int> result = new List<int>();
            for (int i = 1; i <= 9; i++)
            {

            }
            return result;
        }   
    }
}
