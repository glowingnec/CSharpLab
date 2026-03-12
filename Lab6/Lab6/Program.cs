using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab6_EmployeeManagement
{
    public interface ITax
    {
        double CalculateTax();
    }

    public abstract class Employee : ITax
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double BaseSalary { get; set; }

        public Employee(int id, string name, double baseSalary)
        {
            Id = id;
            Name = name;
            BaseSalary = baseSalary;
        }

        public abstract double CalculateSalary();

        public double CalculateTax()
        {
            return 0.1 * CalculateSalary();
        }

        public virtual void Display()
        {
            Console.WriteLine($"ID: {Id} | Tên: {Name} | Lương CB: {BaseSalary:N0}");
        }
    }

    public class FullTimeEmployee : Employee
    {
        public double Bonus { get; set; }

        public FullTimeEmployee(int id, string name, double baseSalary, double bonus)
            : base(id, name, baseSalary)
        {
            Bonus = bonus;
        }

        public override double CalculateSalary()
        {
            return BaseSalary + Bonus;
        }

        public override void Display()
        {
            Console.WriteLine($"[FullTime] ID: {Id} | Tên: {Name} | Lương CB: {BaseSalary:N0} | Bonus: {Bonus:N0} | Tổng Lương: {CalculateSalary():N0} | Thuế: {CalculateTax():N0}");
        }
    }

    public class PartTimeEmployee : Employee
    {
        public int WorkingHours { get; set; }
        public double HourRate { get; set; }

        public PartTimeEmployee(int id, string name, int workingHours, double hourRate)
            : base(id, name, 0)
        {
            WorkingHours = workingHours;
            HourRate = hourRate;
        }

        public override double CalculateSalary()
        {
            return WorkingHours * HourRate;
        }

        public override void Display()
        {
            Console.WriteLine($"[PartTime] ID: {Id} | Tên: {Name} | Giờ làm: {WorkingHours} | Giá/giờ: {HourRate:N0} | Tổng Lương: {CalculateSalary():N0} | Thuế: {CalculateTax():N0}");
        }
    }

    class Program
    {
        static List<Employee> employees = new List<Employee>();

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            while (true)
            {
                Console.WriteLine("\n=== QUẢN LÝ NHÂN VIÊN ===");
                Console.WriteLine("1. Thêm nhân viên FullTime");
                Console.WriteLine("2. Thêm nhân viên PartTime");
                Console.WriteLine("3. Xuất danh sách nhân viên");
                Console.WriteLine("4. Tính tổng lương công ty");
                Console.WriteLine("5. Tìm nhân viên lương cao nhất");
                Console.WriteLine("6. Thoát");
                Console.Write("Chọn chức năng: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddFullTime();
                        break;
                    case "2":
                        AddPartTime();
                        break;
                    case "3":
                        ShowList();
                        break;
                    case "4":
                        ShowTotalSalary();
                        break;
                    case "5":
                        FindHighestSalary();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }
            }
        }

        static double GetValidNumber(string message, bool isInt = false)
        {
            while (true)
            {
                try
                {
                    Console.Write(message);
                    string input = Console.ReadLine();
                    double value = double.Parse(input);

                    if (value < 0) throw new Exception("Giá trị không được âm!");

                    if (isInt && value % 1 != 0) throw new Exception("Vui lòng nhập số nguyên!");

                    return value;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Lỗi: Vui lòng nhập đúng định dạng số!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi: {ex.Message}");
                }
            }
        }

        static void AddFullTime()
        {
            Console.WriteLine("\n--- Thêm FullTime ---");
            int id = (int)GetValidNumber("Nhập ID: ", true);
            Console.Write("Nhập Tên: ");
            string name = Console.ReadLine();
            double baseSalary = GetValidNumber("Nhập Lương Căn Bản: ");
            double bonus = GetValidNumber("Nhập Bonus: ");

            employees.Add(new FullTimeEmployee(id, name, baseSalary, bonus));
            Console.WriteLine("Thêm thành công!");
        }

        static void AddPartTime()
        {
            Console.WriteLine("\n--- Thêm PartTime ---");
            int id = (int)GetValidNumber("Nhập ID: ", true);
            Console.Write("Nhập Tên: ");
            string name = Console.ReadLine();
            int hours = (int)GetValidNumber("Nhập Giờ làm việc: ", true);
            double rate = GetValidNumber("Nhập Lương theo giờ: ");

            employees.Add(new PartTimeEmployee(id, name, hours, rate));
            Console.WriteLine("Thêm thành công!");
        }

        static void ShowList()
        {
            Console.WriteLine("\n--- Danh sách nhân viên ---");
            if (employees.Count == 0) Console.WriteLine("Danh sách trống.");
            foreach (var emp in employees)
            {
                emp.Display();
            }
        }

        static void ShowTotalSalary()
        {
            double total = 0;
            foreach (var emp in employees)
            {
                total += emp.CalculateSalary();
            }
            Console.WriteLine($"\nTổng lương công ty: {total:N0} VND");
        }

        static void FindHighestSalary()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("Danh sách trống.");
                return;
            }

            var maxEmp = employees.OrderByDescending(e => e.CalculateSalary()).FirstOrDefault();
            Console.WriteLine("\n--- Nhân viên lương cao nhất ---");
            maxEmp.Display();
        }
    }
}