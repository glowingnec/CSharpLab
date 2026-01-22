using System;

namespace Lab3_Bai4
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Employee(int id, string name, int age)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Age: {Age}";
        }
    }

    public class Department
    {
        private string name;
        private Employee[] employees;

        public Department(string name, int capacity)
        {
            this.name = name;
            this.employees = new Employee[capacity];
        }

        public Employee this[int index]
        {
            get
            {
                if (index < 0 || index >= employees.Length)
                    throw new IndexOutOfRangeException();
                return employees[index];
            }
            set
            {
                if (index < 0 || index >= employees.Length)
                    throw new IndexOutOfRangeException();
                employees[index] = value;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Department dept = new Department("IT Dept", 3);

            dept[0] = new Employee(1, "Nguyen Van A", 22);
            dept[1] = new Employee(2, "Tran Thi B", 21);
            dept[2] = new Employee(3, "Le Van C", 23);

            for (int i = 0; i < 3; i++)
            {
                if (dept[i] != null)
                    Console.WriteLine(dept[i].ToString());
            }

            try
            {
                Console.WriteLine(dept[5]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Lỗi: Chỉ số vượt quá giới hạn mảng.");
            }

            Console.ReadKey();
        }
    }
}