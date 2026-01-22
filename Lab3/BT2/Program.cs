using System;

namespace Lab3_Bai2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int[,] matrix = {
                { 10, 2, 3, 4 },
                { 5, 14, 7, 8 },
                { 9, 1, 11, 12 },
                { 13, 6, 15, 7 }
            };

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            Console.WriteLine("Nội dung mảng:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }

            int sumDiag = 0;
            for (int i = 0; i < rows; i++)
            {
                if (i < cols) sumDiag += matrix[i, i];
            }
            Console.WriteLine($"Tổng phần tử hàng = cột: {sumDiag}");

            Console.WriteLine("Phần tử nhỏ nhất trên mỗi cột:");
            for (int j = 0; j < cols; j++)
            {
                int minCol = matrix[0, j];
                for (int i = 1; i < rows; i++)
                {
                    if (matrix[i, j] < minCol) minCol = matrix[i, j];
                }
                Console.WriteLine($"Cột {j}: {minCol}");
            }

            Console.Write("Các phần tử chia hết cho 7: ");
            foreach (int item in matrix)
            {
                if (item % 7 == 0) Console.Write(item + " ");
            }
            Console.WriteLine();

            int sumBorder = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i == 0 || i == rows - 1 || j == 0 || j == cols - 1)
                    {
                        sumBorder += matrix[i, j];
                    }
                }
            }
            Console.WriteLine($"Tổng các phần tử đường viền: {sumBorder}");

            int[] flatArr = new int[rows * cols];
            int index = 0;
            foreach (int item in matrix)
            {
                flatArr[index++] = item;
            }
            Array.Sort(flatArr);
            Console.Write("Mảng 1 chiều sau khi chuyển và sắp xếp: ");
            foreach (int item in flatArr) Console.Write(item + " ");
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}