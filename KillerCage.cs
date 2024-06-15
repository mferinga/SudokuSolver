namespace SudokuSolver
{
    public class KillerCage
    {
        private List<int[]> positionKillerCells;
        private int sumOfKillerCage;
        private List<int> filledInValues;

        public KillerCage(int sum, List<int[]> positions) 
        { 
            this.sumOfKillerCage = sum;
            this.positionKillerCells = positions;
            filledInValues = new List<int>();
        }

        public List<int[]> getPositions()
        {
            return positionKillerCells;
        }
        public int getSum()
        {
            return sumOfKillerCage;
        }
        public List<int> getFilledInValues()
        {
            return filledInValues;
        }
    }
}
