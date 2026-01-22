using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab63
{
    class Program
    {
        static void Main(string[] args)
        {
            // Tạo đối tượng book với 4 chương
            Book b = new Book("Programming with Csharp", 4);

            // Nhập thông tin các chương qua Indexer số nguyên
            b[0] = new Chapter("Chapter 1", "Introduction to Csharp");
            b[1] = new Chapter("Chapter 2", "DataType and Variables in Csharp");
            b[2] = new Chapter("Chapter 3", "Input and Output in Console Application");
            b[3] = new Chapter("Chapter 4", "Statements Conditions and Loops");

            // In thông tin sách
            Console.WriteLine("Thong tin sach:");
            Console.WriteLine("Ten sach: " + b.Name);
            Console.WriteLine("-------------------------");

            // In danh sách các chương
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(b[i]); // Tự động gọi ToString() của Chapter
            }

            Console.WriteLine("-------------------------");

            // Tìm và in thông tin chương 3 qua Indexer chuỗi (tên chương)
            Console.WriteLine("Thong tin chuong 3 (Tim theo ten):");
            Console.WriteLine(b["Chapter 3"]);

            Console.Read();
        }
    }
}