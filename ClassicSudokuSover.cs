using SudokuSolver;

class ClassicSudokuSover
{
    private ConstraintChecker _constraintChecker;
    private int[][] _grid;

    private int _currentRow;
    private int _currentCol;

    public ClassicSudokuSover()
    {
        _constraintChecker = new ConstraintChecker();
        GenerateSudoku();

        _currentRow = 0;
        _currentCol = 0;
    }


    public void GenerateSudoku()
    {
        int[][] grid1 = [
                [5, 0, 8, 0, 4, 7, 9, 0, 0],
                [1, 0, 7, 0, 0, 0, 0, 0, 0],
                [0, 0, 2, 1, 0, 0, 6, 0, 7],
                [0, 0, 0, 3, 0, 0, 4, 0, 0],
                [0, 3, 4, 9, 0, 0, 0, 6, 2],
                [2, 1, 0, 6, 0, 4, 0, 0, 0],
                [9, 2, 0, 0, 0, 1, 0, 0, 5],
                [8, 5, 1, 0, 3, 9, 7, 0, 0],
                [4, 7, 0, 0, 0, 6, 8, 9, 1],
            ];

        _grid = grid1;
    }

    // Make method recursive and it must return a int[][] in other words the solution
    public void SudokuSolver()
    {
        if (_grid[_currentRow][_currentCol] == 0)
        {

        } else
        {
            if(_currentCol != 8)
            {
                _currentCol++;
            } else if(_currentRow != 8)
            {
                _currentCol = 0;
                _currentRow++;
            } else
            {
                return;
            }
            
        }
    }

    public int[][] getGrid()
    {
        return _grid;
    }


     


}