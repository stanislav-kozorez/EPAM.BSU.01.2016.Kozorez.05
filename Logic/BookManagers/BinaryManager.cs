using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Logic.BookManagers
{
    public sealed class BinaryManager : IBookManager
    {
        private readonly string fileName;
        public BinaryManager(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException($"{nameof(fileName)} is null");
            this.fileName = fileName;
        }
        public List<Book> Load()
        {
            List<Book> result = new List<Book>();
            if (File.Exists(fileName))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                {
                    while (reader.PeekChar() != -1)
                    {
                        string name = reader.ReadString();
                        string author = reader.ReadString();
                        int year = reader.ReadInt32();
                        result.Add(new Book(name, author, year));
                    }
                }
            }
            else
                throw new FileNotFoundException($"File {fileName} doesn't exist");
            return result;
        }

        public void Save(IEnumerable<Book> books)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                foreach (var book in books)
                {
                    writer.Write(book.Name);
                    writer.Write(book.Author);
                    writer.Write(book.Year);
                }
            }
        }
    }
}
