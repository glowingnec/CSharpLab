using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab4_Bai2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("BÀI 2");

            Console.Write("Nhập chuỗi bất kỳ (cả chữ và số): ");
            string strInput = Console.ReadLine();

            bool hasNumber = Regex.IsMatch(strInput, @"\d");
            Console.WriteLine($"\n- Chuỗi có chứa số không?: {(hasNumber ? "Có" : "Không")}");

            if (hasNumber)
            {
                Console.WriteLine("- Các số tách ra được từ chuỗi:");
                MatchCollection numbers = Regex.Matches(strInput, @"\d+");
                foreach (Match m in numbers)
                {
                    Console.WriteLine("  " + m.Value);
                }
            }

            Console.Write("\nNhập SĐT cần kiểm tra: ");
            string phoneInput = Console.ReadLine();

            string phonePattern = @"^\(\d{2}\)\s\d{3}\s\d{3,4}\s\d{3}$";

            if (Regex.IsMatch(phoneInput, phonePattern))
            {
                Console.WriteLine("=> SĐT đúng định dạng.");
            }
            else
            {
                Console.WriteLine("=> SĐT sai định dạng.");
            }

            Console.Write("\nNhập Email cần kiểm tra: ");
            string emailInput = Console.ReadLine();

            string emailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

            if (Regex.IsMatch(emailInput, emailPattern))
            {
                Console.WriteLine("=> Email hợp lệ.");
            }
            else
            {
                Console.WriteLine("=> Email không hợp lệ.");
            }

            Console.ReadKey();
        }
    }
}