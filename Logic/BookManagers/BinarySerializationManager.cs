using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Logic.BookManagers
{
    public class BinarySerializationManager : IBookManager
    {
        private string fileName;
        public BinarySerializationManager(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException(nameof(fileName));
            this.fileName = fileName;
        }
        public List<Book> Load()
        {
            List<Book> result;
            if (File.Exists(fileName))
            {
                if (new FileInfo(fileName).Extension != ".bin")
                    throw new ArgumentException($"wrong type of file {fileName}");

                using (var stream = File.Open(fileName, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    result = (List<Book>)bf.Deserialize(stream);
                }
            }
            else
                throw new FileNotFoundException($"File {fileName} doesn't exist");
            return result;
        }

        public void Save(IEnumerable<Book> books)
        {
            if (books == null)
                throw new ArgumentNullException(nameof(books));

            using (var stream = File.Open(fileName, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream, books);
            }
        }
    }
}
