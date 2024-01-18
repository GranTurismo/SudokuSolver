using System;
using SudokuSolver;

class Program
{

    public static void Main()
    {
        for (int i = 0; i < 15; i++)
        {
            
        }
    }
    public static string Start(string data)
    {
        int[,] matrix = MatrixManager.GenerateMatrix(data);
        MatrixManager mm = new MatrixManager(matrix);
        while (!mm.IsSolved())
        {
            mm.Solve();
        }


        string s = "";
        for (int i = 0; i < mm._matrix.GetLength(0); i++)
        {
            for (int j = 0; j < mm._matrix.GetLength(1); j++)
            {
                s += $"{mm._matrix[j, i]}";
            }
        }

        return s;
    }
}