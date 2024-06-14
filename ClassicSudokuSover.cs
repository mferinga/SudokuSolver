using SudokuSolver;
using System.Collections.Generic;

class ClassicSudokuSover
{
    private ConstraintChecker _constraintChecker;
    private int[][] _grid;


    public ClassicSudokuSover()
    {
        _constraintChecker = new ConstraintChecker();
        GenerateSudoku();
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

        int[][] grid2 = [
                [7, 0, 0, 6, 0, 1, 0, 0, 3], //5
                [0, 0, 0, 0, 4, 0, 0, 0, 0], //13
                [0, 8, 0, 3, 0, 9, 0, 4, 0], //18
                [0, 0, 5, 0, 9, 0, 1, 0, 0], //24
                [0, 9, 0, 0, 0, 0, 0, 3, 0], //31
                [0, 0, 3, 0, 1, 0, 4, 0, 0], //37
                [0, 6, 0, 4, 0, 7, 0, 1, 0], //42
                [0, 0, 0, 0, 2, 0, 0, 0, 0], //50
                [3, 0, 0, 1, 0, 6, 0, 0, 9], //55
            ];

        _grid = grid2;
    }

    public bool SudokuSolver()
    {
        //position of the the next empty cell by int[row][col]
        int[] emptyCell = getEmptyCell();
        int rowOfEmptyCell = emptyCell[0];
        int colOfEmptyCell = emptyCell[1];

        //sudoku is finshed all cells are filled
        if (rowOfEmptyCell == -1 && colOfEmptyCell == -1)
        {
            return true;
        }

        //get all values of the cells current row, collumn and box
        int[] rowValues = _grid[rowOfEmptyCell];
        int[] colValues = getColValues(colOfEmptyCell);
        int[] boxValues = getBoxValues(rowOfEmptyCell, colOfEmptyCell);

        //if (_grid[rowOfEmptyCell][colOfEmptyCell] == 0)
        //{
        //    //if there is a naked single in that cell fills it in other wise it proceeds
        //    fillInNakedSingle(rowValues, colValues, boxValues, rowOfEmptyCell, colOfEmptyCell);
        //    if (SudokuSolver())
        //    {
        //        return true;
        //    }
        //}

        for (int guess = 1; guess <= 9; guess++)
        {
            if(_constraintChecker.GuessCheck(rowValues, colValues, boxValues, guess))
            {
                _grid[rowOfEmptyCell][colOfEmptyCell] = guess;

                if (SudokuSolver())
                {
                    return true;
                }

                _grid[rowOfEmptyCell][colOfEmptyCell] = 0;
            }
        }
        
        //no solution found
        return false;
    }

    public int[][] getGrid()
    {
        return _grid;
    }

    private int[] getEmptyCell()
    {
        //if grid is fully filled give impossible grid possition
        int[] emptycell = new int[] { -1, -1 };

        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                if (_grid[row][col] == 0)
                {
                    emptycell[0] = row;
                    emptycell[1] = col;
                    return emptycell;
                }
            }
        }

        return emptycell;
    }

    private void fillInNakedSingle(int[] row, int[] col, int[] box, int curRow, int curCol)
    {
        List<int> possibleNumbers = _constraintChecker.CheckAllConstraints(row, col, box);

        //check if current cell is a naked single (so we don't have to make a guess)
        int numToFill = checkAppearsThreeTimes(possibleNumbers);
        if (numToFill != 0)
        {
            _grid[curRow][curCol] = checkAppearsThreeTimes(possibleNumbers);
        }


    }

    //checks on naked singles
    private int checkAppearsThreeTimes(List<int> list)
    {
        var frequency = list.GroupBy(n => n)
                            .Select(group => new { Number = group.Key, Count = group.Count() })
                            .ToList();

        //check if there is exactly one number that appears three times 
        //find the number that appears exactly three times
        var numberAppearingThrice = frequency.FirstOrDefault(f => f.Count == 3)?.Number;

        //check if there is exactly one number that appears three times
        if (numberAppearingThrice != null && frequency.Count(f => f.Count == 3) == 1)
        {
            return numberAppearingThrice.Value;
        }
        return 0;
    }

    //private int getBox()
    //{
    //    int boxNumber;
    //    boxNumber = (_currentCol / 3 + 1) + (_currentRow / 3 * 3);
        
    //    //debug code -->
    //    //Console.WriteLine("colNumberBox: " + _currentCol + " horizontal box = " + (_currentCol / 3 + 1) + 
    //    //    "\nrowNumberBox: " + _currentRow + " vertical box = " + (_currentRow / 3 * 3) +
    //    //    "\ntotal box number = " + boxNumber);
        
    //    return boxNumber;
    //}

    private int[] getBoxValues(int curRow, int curCol)
    {
        List<int> values = new List<int>();

        int[] rows = checkRow(curRow);
        int[] colls = checkCollumns(curCol);

        foreach (int row in rows)
        {
            foreach (int col in colls)
            {
                values.Add(_grid[row][col]); 
            }
        }
        
        return values.ToArray();
    }

    private int[] getColValues(int col)
    {
        List<int> colList = new List<int>();
        for (int i = 0; i < 9; i++)
        {
            colList.Add(_grid[i][col]);
        }
        return colList.ToArray();
    }

    private int[] checkRow(int row)
    {
        List<int> rows = new List<int>();
        if (row < 3)
        {
            rows.AddRange(new List<int> { 0, 1, 2});
        }
        else if (row < 6)
        {
            rows.AddRange(new List<int> { 3, 4, 5 });
        }
        else
        {
            rows.AddRange(new List<int> { 6, 7, 8 });
        }

        return rows.ToArray();
    }

    private int[] checkCollumns(int col)
    {
        List<int> colls = new List<int>();
        if (col < 3)
        {
            colls.AddRange(new List<int> { 0, 1, 2 });
        }
        else if (col < 6)
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