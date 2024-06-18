namespace SudokuSolver
{
    public class KillerCage
    {
        private List<int[]> positionKillerCells;
        private int sumOfKillerCage;
        private List<int> filledInValues;
        private int sumOfFilledInValues;

        public KillerCage(int sum, List<int[]> positions) 
        { 
            this.sumOfKillerCage = sum;
            this.positionKillerCells = positions;
            filledInValues = new List<int>();
        }

        public int getSumOfFilledInValues()
        {
            sumOfFilledInValues = 0;
            foreach (int value in filledInValues)
            {
                sumOfFilledInValues += value;
            }

            return sumOfFilledInValues;
        }
        public List<int[]> getPositions()
        {
            return positionKillerCells;
        }
        public int getSum()
        {
            return sumOfKillerCage;
        }
        public void addFilledValue(int value)
        {
            filledInValues.Add(value);
        }
        public void removeFilledValue(int value) 
        {
            filledInValues.Remove(value); 
        }
        public List<int> getFilledInValues()
        {
            return filledInValues;
        }
    }
}
