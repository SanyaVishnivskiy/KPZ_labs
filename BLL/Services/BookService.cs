using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BookService : IBookService
{
    private readonly LibraryContext context;
    public BookService(LibraryContext context)
    {
        this.context = context;
    }

    public IEnumerable<Book> SearchBookByAuthor(string keyAuthor)
    {
        return context.Books.Where(x => x.Name.Contains(keyAuthor));
    }

    public IEnumerable<Book> SearchBookByTag(Tag keyTag)
    {
        return context.Books.Where(x => x.BookTags == x.BookTags.Where(a => a.Tag == keyTag));
    }

    public IEnumerable<Book> SearchBookByTitle(string keyTitle)
    {
        return context.Books.Where(x => x.Name.Contains(keyTitle));
    }

    public IEnumerable<Book> SearchBookByYear(int keyYear)
    {
        return context.Books.Where(x => x.Year == keyYear);
    }
}
