namespace SudokuSolver
{
    public class ConstraintChecker
    {
        List<int> result = new List<int>();

        //Checks for duplicates in the row, column and box in classic sudoku
        public bool GuessCheck(int[] row, int[] col, int[] box, int guess)
        {
            if(row.Contains(guess) ||  col.Contains(guess) || box.Contains(guess))
            {
                return false;
            }

            return true;
        }

        //Checks for duplicates in the row, column, box and cage in killer sudoku
        public bool KillerDuplicateCheck(int[] row, int[] col, int[] box, int[] cage, int guess)
        {
            if (row.Contains(guess) || col.Contains(guess) || box.Contains(guess) || cage.Contains(guess))
            {
                return false;
            }

            return true;
        }

        //Checks if the sum of the cage is correct or guess can be added to the cage
        public bool checkCageSum(KillerCage cage,int guess)
        {
            int sumToBe = cage.getSum();
            int currentSumOfFilledInValues = cage.getSumOfFilledInValues();

            if(currentSumOfFilledInValues + guess > sumToBe)
            {
                return false;
            }

            int amountOfPositions = cage.getPositions().Count;
            int amountOfFilledInValues = cage.getFilledInValues().Count;

            if (amountOfFilledInValues + 1 > amountOfPositions)
            {
                return false;
            }

            if(amountOfFilledInValues + 1 == amountOfPositions)
            {
                if (currentSumOfFilledInValues + guess != sumToBe)
                {
                    return false;
                } 
            }
            return true;
        }
    }
}
