namespace SudokuSolver
{
    public class KillerSudoku
    {
        public int[,] grid { get; }
        public List<KillerCage> cages { get; }

        public KillerSudoku(int[,] grid, List<KillerCage> cages)
        {
            this.grid = grid;
            this.cages = cages;
        }
        public void addCage(KillerCage cage)
        {
            cages.Add(cage);
        }
    }
}
