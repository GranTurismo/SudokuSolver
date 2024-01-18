namespace SudokuSolver;

public class MatrixManager
{
    public int[,] _matrix;
    
    public MatrixManager(int[,] matrix) => _matrix = matrix;
    
    public int[] GetRow(int row)
    {
        int[] dimen = new int[9];

        for (int i = 0; i < _matrix.GetLength(0); i++)
        {
                dimen[i] = _matrix[i, row];
        }

        return dimen;
    }
    
    public int[] GetCol(int row)
    {
        int[] dimen = new int[9];

        for (int i = 0; i < _matrix.GetLength(0); i++)
        {
            dimen[i] = _matrix[row,i];
        }

        return dimen;
    }

    public void PrintMatrix(int[,]? matrix)
    {
        if (matrix == null)
            matrix = _matrix;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i,j]} ");
            }

            Console.WriteLine();
        }
    }

    public bool IsSolved()
    {
        for(int i=0;i<_matrix.GetLength(0);i++)
            for(int j=0;j<_matrix.GetLength(1);j++)
                if (_matrix[i, j] == 0)
                    return false;

        return true;
    }

    public int[,] GetCubeOf(int row, int col)
    {
        int[,] cube = new int[3,3];

        int rowStart = row-row%3;
        int colStart = col-col%3;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                cube[j,i] = _matrix[rowStart + i, colStart + j];
            }
        }

        return cube;
    }
    
    public static int[,] GenerateMatrix(string data)
    {
        int x = 0;
        int y = 0;

        int[,] matrix=new int[9,9];
        foreach (char d in data)
        {
            if (x == 9)
            {
                x = 0;
                y++;
            }

            matrix[x++, y] = int.Parse(d.ToString());
        }

        return matrix;
    }

    public void Solve()
    {
        for(int i=0;i<_matrix.GetLength(0);i++)
        for (int j = 0; j < _matrix.GetLength(1); j++)
        {
            List<int> nums = FindNum(i, j);
            if (nums.Count == 1)
            {
                _matrix[i, j] = nums[0];
            }
        }
    }

    public List<int> FindNum(int row, int col)
    {
        List<int> numbers = new List<int>();

        if (_matrix[row, col] != 0)
            return numbers;

        for (int i = 1; i <= 9; i++)
        {
            bool[] isInvalidNumber = new bool[3];
            isInvalidNumber[0] = GetRow(col).Contains(i);
            isInvalidNumber[1] = GetCol(row).Contains(i);
            isInvalidNumber[2] = DoesCubeContains(row,col,i);

            if (isInvalidNumber.All(o => !o))
                numbers.Add(i);
        }

        return numbers;
    }

    public bool DoesCubeContains(int row,int col,int r)
    {
        int[,] cube = GetCubeOf(row, col);

        for (int i = 0; i < cube.GetLength(0); i++)
            for(int j=0;j<cube.GetLength(1);j++)
                if (cube[i, j] == r)
                    return true;
        
        return false;
    }
}