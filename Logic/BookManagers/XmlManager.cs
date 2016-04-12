using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Logic.BookManagers
{
    public class XmlManager: IBookManager
    {
        private string fileName;
        public XmlManager(string fileName)
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
                if (new FileInfo(fileName).Extension != ".xml")
                    throw new ArgumentException($"wrong type of file {fileName}");

                using (var stream = File.Open(fileName, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
                    result = (List<Book>)serializer.Deserialize(stream);
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
                XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
                serializer.Serialize(stream, books);
            }
        }
    }
}
