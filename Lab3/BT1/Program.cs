using System;

namespace Lab3_Bai1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int[] arr = { 5, -2, 11, 7, -9, 4, 3, 13, -1, 6 };
            Console.Write("Mảng ban đầu: ");
            foreach (int x in arr) Console.Write(x + " ");
            Console.WriteLine();

            int minVal = arr[0];
            foreach (int x in arr)
            {
                if (x < minVal) minVal = x;
            }
            Console.WriteLine($"Phần tử nhỏ nhất: {minVal}");

            int[] reversedArr = (int[])arr.Clone();
            Array.Reverse(reversedArr);
            Console.Write("Mảng đảo ngược: ");
            foreach (int x in reversedArr) Console.Write(x + " ");
            Console.WriteLine();

            int[] sortedArr = (int[])arr.Clone();
            Array.Sort(sortedArr);
            Console.Write("Mảng sắp xếp tăng dần: ");
            foreach (int x in sortedArr) Console.Write(x + " ");
            Console.WriteLine();

            Console.Write("Các số nguyên tố: ");
            foreach (int x in arr)
            {
                if (IsPrime(x)) Console.Write(x + " ");
            }
            Console.WriteLine();

            int maxConsecutive = 0;
            int currentConsecutive = 0;
            foreach (int x in arr)
            {
                if (x > 0)
                {
                    currentConsecutive++;
                }
                else
                {
                    if (currentConsecutive > maxConsecutive) maxConsecutive = currentConsecutive;
                    currentConsecutive = 0;
                }
            }
            if (currentConsecutive > maxConsecutive) maxConsecutive = currentConsecutive;
            Console.WriteLine($"Số lượng số dương liên tiếp nhiều nhất: {maxConsecutive}");

            double sumPos = 0;
            int countPos = 0;
            foreach (int x in arr)
            {
                if (x > 0)
                {
                    sumPos += x;
                    countPos++;
                }
            }
            if (countPos > 0)
                Console.WriteLine($"Trung bình cộng số dương: {sumPos / countPos}");

            bool isAlternating = true;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] * arr[i + 1] >= 0)
                {
                    isAlternating = false;
                    break;
                }
            }
            Console.WriteLine(isAlternating ? "Mảng có đan xen âm dương." : "Mảng KHÔNG đan xen âm dương.");

            Console.ReadKey();
        }

        static bool IsPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0) return false;
            return true;
        }
    }
}