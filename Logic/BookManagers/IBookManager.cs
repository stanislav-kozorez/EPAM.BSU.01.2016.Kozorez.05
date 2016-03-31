using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.BookManagers
{
    public interface IBookManager
    {
        List<Book> Load();
        void Save(IEnumerable<Book> books);
    }
}
