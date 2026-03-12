using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Lab4_Bai1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("BÀI 1");
            Console.Write("Nhập vào một chuỗi: ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Chuỗi rỗng!");
                Console.ReadKey();
                return;
            }

            string reversed = new string(input.Reverse().ToArray());
            Console.WriteLine($"\n1. Chuỗi đảo ngược: {reversed}");

            bool isPalindrome = input.Equals(reversed, StringComparison.OrdinalIgnoreCase);
            Console.WriteLine($"2. Chuỗi có đối xứng không?: {(isPalindrome ? "Có" : "Không")}");

            string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($"3. Số từ trong chuỗi: {words.Length}");

            
            string noSpecialChars = Regex.Replace(input, @"[^\w\sàáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹđÀÁẠẢÃÂẦẤẬẨẪĂẰẮẶẲẴÈÉẸẺẼÊỀẾỆỂỄÌÍỊỈĨÒÓỌỎÕÔỒỐỘỔỖƠỜỚỢỞỠÙÚỤỦŨƯỪỨỰỬỮỲÝỴỶỸĐ]", "");

            string singleSpaced = Regex.Replace(noSpecialChars, @"\s+", " ").Trim();

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string normalized = textInfo.ToTitleCase(singleSpaced.ToLower());

            Console.WriteLine($"4. Chuỗi chuẩn hóa: {normalized}");

            Console.ReadKey();
        }
    }
}