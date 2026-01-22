using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab61
{
    class Program
    {
        static void Main(string[] args)
        {
            // Khai báo và khởi tạo mảng 1 chiều
            // (Đã sửa lại các ký tự lỗi từ PDF gốc)
            int[] m = { 5, 8, 3, 0, 2, 1, 7, 8 };

            // Duyệt mảng và in dữ liệu
            Console.Write("Cac phan tu cua mang: ");
            for (int i = 0; i < m.Length; i++)
            {
                Console.Write("{0} ", m[i]);
            }
            Console.WriteLine();

            // Tìm phần tử lớn nhất
            int max = m[0];
            for (int i = 0; i < m.Length; i++)
            {
                if (max < m[i])
                {
                    max = m[i];
                }
            }
            Console.WriteLine("Phan tu lon nhat: " + max);

            // Kiểm tra mảng có đối xứng không?
            bool kt = true;
            for (int i = 0; i < m.Length / 2; i++)
            {
                // So sánh phần tử đầu và phần tử đối xứng ở cuối
                if (m[i] != m[m.Length - 1 - i])
                {
                    kt = false;
                    break;
                }
            }

            if (kt)
                Console.WriteLine("Mang doi xung");
            else
                Console.WriteLine("Mang khong doi xung");

            // Giữ màn hình để xem kết quả
            Console.ReadLine();
        }
    }
}