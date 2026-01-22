using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab62
{
    class Program
    {
        static void Main(string[] args)
        {
            // Khai báo và khởi tạo mảng 2 chiều (4 hàng, 3 cột)
            int[,] a = {
                {4, 6, 9},
                {2, 4, 5},
                {9, 2, 6},
                {1, 6, 3}
            };

            // Duyệt mảng và in theo hàng cột
            Console.WriteLine("Noi dung mang:");
            for (int i = 0; i <= a.GetUpperBound(0); i++) // Duyệt hàng
            {
                for (int j = 0; j <= a.GetUpperBound(1); j++) // Duyệt cột
                {
                    Console.Write("{0} ", a[i, j]);
                }
                Console.WriteLine();
            }

            // Tìm các phần tử có chỉ số hàng bằng chỉ số cột
            Console.WriteLine("Cac phan tu co chi so hang bang chi so cot:");
            for (int i = 0; i <= a.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= a.GetUpperBound(1); j++)
                {
                    if (i == j)
                    {
                        Console.Write("{0} ", a[i, j]);
                    }
                }
            }
            Console.WriteLine();

            // Các phần tử lớn nhất trên hàng
            Console.WriteLine("Cac phan tu lon nhat tren hang:");
            for (int i = 0; i <= a.GetUpperBound(0); i++)
            {
                int max = a[i, 0];
                for (int j = 0; j <= a.GetUpperBound(1); j++)
                {
                    if (max < a[i, j])
                    {
                        max = a[i, j];
                    }
                }
                Console.WriteLine("Hang {0}: {1}", i, max);
            }

            Console.ReadLine();
        }
    }
}