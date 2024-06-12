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
    public void SudokuSolver(int[][] grid)
    {
        List<int> possibleNumbers = new List<int>();
        
        if (_grid[_currentRow][_currentCol] == 0)
        {
            int[] row = _grid[_currentRow];
            List<int> colList = new List<int>();
            for (int i = 0; i < 9; i++)
            {
                colList.Add(_grid[i][_currentCol]);
            }
            int[] col = colList.ToArray();

            possibleNumbers.Union(_constraintChecker.rowCheck(row)).ToList();
            possibleNumbers.Union(_constraintChecker.collumnCheck(col)).ToList();
            possibleNumbers.Union(_constraintChecker.rowCheck(row)).ToList();
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

    public int getBox()
    {
        int boxNumber;
        boxNumber = (_currentCol / 3 + 1) + (_currentRow / 3 * 3);
        
        //debug code -->
        //Console.WriteLine("colNumberBox: " + _currentCol + " horizontal box = " + (_currentCol / 3 + 1) + 
        //    "\nrowNumberBox: " + _currentRow + " vertical box = " + (_currentRow / 3 * 3) +
        //    "\ntotal box number = " + boxNumber);
        
        return boxNumber;
    }

    //get values of every number inside of the box
    public int[][] getBoxValues()
    {
        throw new NotImplementedException();
    }
     


}