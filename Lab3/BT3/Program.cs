using System;

namespace Lab3_Bai3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string[] Can = { "Canh", "Tân", "Nhâm", "Quý", "Giáp", "Ất", "Bính", "Đinh", "Mậu", "Kỷ" };
            string[] Chi = { "Thân", "Dậu", "Tuất", "Hợi", "Tí", "Sửu", "Dần", "Mão", "Thìn", "Tỵ", "Ngọ", "Mùi" };

            Console.Write("Nhập vào một năm dương lịch: ");
            if (int.TryParse(Console.ReadLine(), out int year))
            {
                string can = Can[year % 10];
                string chi = Chi[year % 12];
                Console.WriteLine($"Năm {year} âm lịch là: {can} {chi}");
            }
            else
            {
                Console.WriteLine("Vui lòng nhập số hợp lệ.");
            }

            Console.ReadKey();
        }
    }
}