using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab63
{
    public class Book
    {
        private string name;
        private Chapter[] chapters;

        public Book() { }

        public Book(string name, int n)
        {
            this.name = name;
            chapters = new Chapter[n];
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                name = value;
            }
        }

        // Indexer 1: Truy cập chương theo chỉ số (int)
        public Chapter this[int index]
        {
            get
            {
                if (index < 0 || index > chapters.Length - 1)
                    return null;
                return chapters[index];
            }
            set
            {
                if (index < 0 || index > chapters.Length - 1)
                    throw new ArgumentOutOfRangeException();
                chapters[index] = value;
            }
        }

        // Indexer 2: Truy cập chương theo tên (string)
        public Chapter this[string name]
        {
            get
            {
                foreach (Chapter ch in chapters)
                {
                    if (ch.Name == name)
                    {
                        return ch;
                    }
                }
                return null;
            }
        }
    }
}