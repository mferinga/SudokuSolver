using SudokuSolver;
using System.Collections.Generic;

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
    public int[][] SudokuSolver()
    {
        List<int> possibleNumbers = new List<int>();
        
        if (_grid[_currentRow][_currentCol] == 0)
        {
            int[] row = _grid[_currentRow];
            int[] col = getColValues();
            int[] box = getBoxValues();

            List<int> rowPos = _constraintChecker.rowCheck(row);
            List<int> colPos = _constraintChecker.collumnCheck(col);
            List<int> boxPos = _constraintChecker.boxCheck(box);

            possibleNumbers.AddRange(rowPos);
            possibleNumbers.AddRange(colPos);
            possibleNumbers.AddRange(boxPos);

            if (checkAppearsThreeTimes(possibleNumbers))
            {
                _grid[_currentRow][_currentCol] = possibleNumbers[0];
            }
        }

        if (_currentRow == 8 && _currentCol == 8)
        {
            return _grid;
        }
        else if (_currentCol < 8)
        {
            _currentCol++;
        }
        else if (_currentCol == 8) 
        {
            _currentCol = 0;
            _currentRow++;
        }

        return SudokuSolver();
    }

    public int[][] getGrid()
    {
        return _grid;
    }

    private bool checkAppearsThreeTimes(List<int> list)
    {
        var frequency = list.GroupBy(n => n)
                            .Select(group => new { Number = group.Key, Count = group.Count() })
                            .ToList();

        // Check if there is exactly one number that appears three times
        return frequency.Count(f => f.Count == 3) == 1;

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

    public int[] getBoxValues()
    {
        List<int> values = new List<int>();

        int[] rows = checkRow();
        int[] colls = checkCollumns();

        foreach (int row in rows)
        {
            foreach (int col in colls)
            {
                values.Add(_grid[row][col]); 
            }
        }
        
        return values.ToArray();
    }

    private int[] getColValues()
    {
        List<int> colList = new List<int>();
        for (int i = 0; i < 9; i++)
        {
            colList.Add(_grid[i][_currentCol]);
        }
        return colList.ToArray();
    }

    private int[] checkRow()
    {
        List<int> rows = new List<int>();
        if (_currentRow < 3)
        {
            rows.AddRange(new List<int> { 0, 1, 2});
        }
        else if (_currentRow < 6)
        {
            rows.AddRange(new List<int> { 3, 4, 5 });
        }
        else
        {
            rows.AddRange(new List<int> { 6, 7, 8 });
        }

        return rows.ToArray();
    }

    private int[] checkCollumns()
    {
        List<int> colls = new List<int>();
        if (_currentCol < 3)
        {
            colls.AddRange(new List<int> { 0, 1, 2 });
        }
        else if (_currentCol < 6)
        {
            colls.AddRange(new List<int> { 3, 4, 5 });
        }
        else
        {
            colls.AddRange(new List<int> { 6, 7, 8 });
        }

        return colls.ToArray();
    }

    public void print()
    {
        for (int n = 0; n < _grid.Length; n++)
        {
            for (int k = 0; k < _grid[n].Length; k++)
            {
                System.Console.Write("{0} ", _grid[n][k]);
            }
            System.Console.WriteLine();
        }
    }



}