using System;

public class MatrixUtility
{
    static Random random = new Random();

    public static double[,] CreateRandomMatrix(int rows, int cols)
    {
        double[,] matrix = new double[rows, cols];

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                matrix[i, j] = random.Next(1, 10);

        return matrix;
    }

    public static double[,] Add(double[,] A, double[,] B)
    {
        int r = A.GetLength(0), c = A.GetLength(1);
        double[,] result = new double[r, c];

        for (int i = 0; i < r; i++)
            for (int j = 0; j < c; j++)
                result[i, j] = A[i, j] + B[i, j];

        return result;
    }

    public static double[,] Subtract(double[,] A, double[,] B)
    {
        int r = A.GetLength(0), c = A.GetLength(1);
        double[,] result = new double[r, c];

        for (int i = 0; i < r; i++)
            for (int j = 0; j < c; j++)
                result[i, j] = A[i, j] - B[i, j];

        return result;
    }

    public static double[,] Multiply(double[,] A, double[,] B)
    {
        int r1 = A.GetLength(0), c1 = A.GetLength(1);
        int c2 = B.GetLength(1);
        double[,] result = new double[r1, c2];

        for (int i = 0; i < r1; i++)
            for (int j = 0; j < c2; j++)
                for (int k = 0; k < c1; k++)
                    result[i, j] += A[i, k] * B[k, j];

        return result;
    }

    public static double[,] Transpose(double[,] A)
    {
        int r = A.GetLength(0), c = A.GetLength(1);
        double[,] t = new double[c, r];

        for (int i = 0; i < r; i++)
            for (int j = 0; j < c; j++)
                t[j, i] = A[i, j];

        return t;
    }

    public static double Determinant2x2(double[,] m)
    {
        return (m[0, 0] * m[1, 1]) - (m[0, 1] * m[1, 0]);
    }

    public static double Determinant3x3(double[,] m)
    {
        return m[0,0]*(m[1,1]*m[2,2] - m[1,2]*m[2,1])
             - m[0,1]*(m[1,0]*m[2,2] - m[1,2]*m[2,0])
             + m[0,2]*(m[1,0]*m[2,1] - m[1,1]*m[2,0]);
    }

    public static double[,] Inverse2x2(double[,] m)
    {
        double det = Determinant2x2(m);
        if (det == 0) return null;

        return new double[,]
        {
            {  m[1,1]/det, -m[0,1]/det },
            { -m[1,0]/det,  m[0,0]/det }
        };
    }

    public static double[,] Inverse3x3(double[,] m)
    {
        double det = Determinant3x3(m);
        if (det == 0) return null;

        double[,] inv = new double[3,3];

        inv[0,0] =  (m[1,1]*m[2,2] - m[1,2]*m[2,1]) / det;
        inv[0,1] = -(m[0,1]*m[2,2] - m[0,2]*m[2,1]) / det;
        inv[0,2] =  (m[0,1]*m[1,2] - m[0,2]*m[1,1]) / det;

        inv[1,0] = -(m[1,0]*m[2,2] - m[1,2]*m[2,0]) / det;
        inv[1,1] =  (m[0,0]*m[2,2] - m[0,2]*m[2,0]) / det;
        inv[1,2] = -(m[0,0]*m[1,2] - m[0,2]*m[1,0]) / det;

        inv[2,0] =  (m[1,0]*m[2,1] - m[1,1]*m[2,0]) / det;
        inv[2,1] = -(m[0,0]*m[2,1] - m[0,1]*m[2,0]) / det;
        inv[2,2] =  (m[0,0]*m[1,1] - m[0,1]*m[1,0]) / det;

        return inv;
    }

    // i) Display matrix
    public static void Display(double[,] m)
    {
        for (int i = 0; i < m.GetLength(0); i++)
        {
            for (int j = 0; j < m.GetLength(1); j++)
                Console.Write($"{m[i, j],8:F2}");
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        double[,] A = CreateRandomMatrix(2, 2);
        double[,] B = CreateRandomMatrix(2, 2);

        Console.WriteLine("Matrix A:");
        Display(A);

        Console.WriteLine("Matrix B:");
        Display(B);

        Console.WriteLine("A + B:");
        Display(Add(A, B));

        Console.WriteLine("A - B:");
        Display(Subtract(A, B));

        Console.WriteLine("A * B:");
        Display(Multiply(A, B));

        Console.WriteLine("Transpose of A:");
        Display(Transpose(A));

        Console.WriteLine($"Determinant of A: {Determinant2x2(A)}");

        double[,] invA = Inverse2x2(A);
        if (invA != null)
        {
            Console.WriteLine("Inverse of A:");
            Display(invA);
        }
        else
        {
            Console.WriteLine("Inverse does not exist (determinant is zero)");
        }
    }
}
