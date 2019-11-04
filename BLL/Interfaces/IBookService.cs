using System;
using DAL.Entities;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IBookService
    {
        IEnumerable<Book> SearchBookByAuthor(string keyAuthor);
        IEnumerable<Book> SearchBookByTag(Tag keyTag);
        IEnumerable<Book> SearchBookByTitle(string keyTitle);
        IEnumerable<Book> SearchBookByYear(int keyYear);
        IEnumerable<Book> GetAllBook();
        Book GetBookById(int id);
    }
}
