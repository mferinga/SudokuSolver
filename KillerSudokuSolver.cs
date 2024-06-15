using SudokuSolver;
using System.Collections.Generic;

class KillerSudokuSolver
{
    private ConstraintChecker _constraintChecker;
    private int[][] _grid;
    private KillerSudoku _killerSudoku;


    public KillerSudokuSolver()
    {
        _constraintChecker = new ConstraintChecker();
        GenerateSudoku();
    }

    public void GenerateSudoku()
    {
        int[][] classicGrid1 = [
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
        int[][] classicGrid2 = [
                [7, 0, 0, 6, 0, 1, 0, 0, 3],
                [0, 0, 0, 0, 4, 0, 0, 0, 0],
                [0, 8, 0, 3, 0, 9, 0, 4, 0],
                [0, 0, 5, 0, 9, 0, 1, 0, 0],
                [0, 9, 0, 0, 0, 0, 0, 3, 0],
                [0, 0, 3, 0, 1, 0, 4, 0, 0],
                [0, 6, 0, 4, 0, 7, 0, 1, 0],
                [0, 0, 0, 0, 2, 0, 0, 0, 0],
                [3, 0, 0, 1, 0, 6, 0, 0, 9],
            ];

        _grid = classicGrid1;
    }

    public void GenerateKillerSudoku()
    {
        KillerSudoku killerSudoku;
        
        int[,] killerGrid1 = 
        {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };
        List<KillerCage> cages1 = new List<KillerCage>();

        cages1 = fillCages(cages1);

        killerSudoku = new KillerSudoku(killerGrid1, cages1);
        _killerSudoku = killerSudoku;

        
    }

    public bool ClassicSudokuSolver()
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

        for (int guess = 1; guess <= 9; guess++)
        {
            if(_constraintChecker.GuessCheck(rowValues, colValues, boxValues, guess))
            {
                _grid[rowOfEmptyCell][colOfEmptyCell] = guess;

                if (ClassicSudokuSolver())
                {
                    return true;
                }

                _grid[rowOfEmptyCell][colOfEmptyCell] = 0;
            }
        }
        
        //no solution found
        return false;
    }

    public bool SolveKillerSudoku()
    {
        return true;
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

    public List<KillerCage> fillCages(List<KillerCage> cages)
    {
        //row 1
        cages.Add(new KillerCage(6, new List<int[]> { new int[] { 0, 0 }, new int[] { 0, 1 }, new int[] { 1, 0 } }));
        cages.Add(new KillerCage(12, new List<int[]> { new int[] { 0, 2 }, new int[] { 0, 3 }, new int[] { 1, 3 } }));
        cages.Add(new KillerCage(14, new List<int[]> { new int[] { 0, 4 }, new int[] { 1, 4 }, new int[] { 1, 5 } }));
        cages.Add(new KillerCage(16, new List<int[]> { new int[] { 0, 5 }, new int[] { 0, 6 }, new int[] { 1, 6 } }));
        cages.Add(new KillerCage(27, new List<int[]> { new int[] { 0, 7 }, new int[] { 0, 8 }, new int[] { 1, 7 }, new int[] { 1, 8 } }));
        //row 2
        cages.Add(new KillerCage(21, new List<int[]> { new int[] { 1, 1 }, new int[] { 1, 2 }, new int[] { 2, 1 } }));
        //row 3
        cages.Add(new KillerCage(7, new List<int[]> { new int[] { 2, 0 }, new int[] { 3, 0 }, new int[] { 3, 1 } }));
        cages.Add(new KillerCage(23, new List<int[]> { new int[] { 2, 2 }, new int[] { 2, 3 }, new int[] { 3, 2 } }));
        cages.Add(new KillerCage(11, new List<int[]> { new int[] { 2, 4 }, new int[] { 2, 5 }, new int[] { 3, 5 } }));
        cages.Add(new KillerCage(16, new List<int[]> { new int[] { 2, 6 }, new int[] { 3, 6 }, new int[] { 3, 7 } }));
        cages.Add(new KillerCage(19, new List<int[]> { new int[] { 2, 7 }, new int[] { 2, 8 }, new int[] { 3, 8 } }));
        //row 4
        cages.Add(new KillerCage(15, new List<int[]> { new int[] { 3, 3 }, new int[] { 3, 4 }, new int[] { 4, 3 } }));
        //row 5
        cages.Add(new KillerCage(20, new List<int[]> { new int[] { 4, 0 }, new int[] { 4, 1 }, new int[] { 5, 1 } }));
        cages.Add(new KillerCage(20, new List<int[]> { new int[] { 4, 2 }, new int[] { 5, 2 }, new int[] { 5, 3 } }));
        cages.Add(new KillerCage(15, new List<int[]> { new int[] { 4, 4 }, new int[] { 4, 5 }, new int[] { 5, 4 } }));
        cages.Add(new KillerCage(14, new List<int[]> { new int[] { 4, 6 }, new int[] { 4, 7 }, new int[] { 5, 7 } }));
        cages.Add(new KillerCage(11, new List<int[]> { new int[] { 4, 8 }, new int[] { 5, 8 }, new int[] { 6, 8 } }));
        //row 6
        cages.Add(new KillerCage(14, new List<int[]> { new int[] { 5, 0 }, new int[] { 6, 0 }, new int[] { 6, 1 } }));
        cages.Add(new KillerCage(7, new List<int[]> { new int[] { 5, 5 }, new int[] { 5, 6 }, new int[] { 6, 5 } }));
        //row 7
        cages.Add(new KillerCage(11, new List<int[]> { new int[] { 6, 2 }, new int[] { 6, 3 }, new int[] { 7, 3 } }));
        cages.Add(new KillerCage(19, new List<int[]> { new int[] { 6, 4 }, new int[] { 7, 4 }, new int[] { 7, 5 } }));
        cages.Add(new KillerCage(17, new List<int[]> { new int[] { 6, 6 }, new int[] { 6, 7 }, new int[] { 7, 6 } }));
        //row 8
        cages.Add(new KillerCage(29, new List<int[]> { new int[] { 7, 0 }, new int[] { 8, 0 }, new int[] { 7, 1 }, new int[] { 8, 1 } }));
        cages.Add(new KillerCage(7, new List<int[]> { new int[] { 7, 2 }, new int[] { 8, 2 }, new int[] { 8, 3 } }));
        cages.Add(new KillerCage(11, new List<int[]> { new int[] { 7, 7 }, new int[] { 7, 8 }, new int[] { 8, 7 }, new int[] { 8, 8 } }));
        //row 9
        cages.Add(new KillerCage(23, new List<int[]> { new int[] { 8, 4 }, new int[] { 8, 5 }, new int[] { 8, 6 } }));

        return cages;
    }
}