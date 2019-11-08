using BLL.Interfaces;
using DAL.EF;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.Exceptions;

namespace BLL.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryContext context;
        public BookService(LibraryContext context)
        {
            this.context = context;
        }

        public IEnumerable<Book> GetAllBook()
        {
            var books = context.Books.ToList();
            if(books == null)
            {
                throw new NotFoundEntitiesException("There are empty");
            }
            else
            {
                return books;
            }
        }

        public Book GetBookById(int id)
        {
            Book book = context.Books.Find(id);

            if (book == null)
            {
                throw new NotFoundEntityException("Book is not found");
            }

            return book;
        }

        public IEnumerable<Book> SearchBookByAuthor(string keyAuthor)
        {
            var books = context.Books.Where(x => x.Name.Contains(keyAuthor));

            if (books == null)
            {
                throw new NotFoundEntityException("Book is not found");
            }

            return books;
        }

        public IEnumerable<Book> SearchBookByTag(Tag keyTag)
        {
            var books = context.Books.Where(x => x.BookTags == x.BookTags.Where(a => a.Tag == keyTag));

            if (books == null)
            {
                throw new NotFoundEntityException("Book is not found");
            }

            return books;
        }

        public IEnumerable<Book> SearchBookByTitle(string keyTitle)
        {
            var books = context.Books.Where(x => x.Name.Contains(keyTitle));

            if (books == null)
            {
                throw new NotFoundEntityException("Book is not found");
            }

            return books;
        }

        public IEnumerable<Book> SearchBookByYear(int keyYear)
        {
            var books = context.Books.Where(x => x.Year == keyYear);

            if (books == null)
            {
                throw new NotFoundEntityException("Book is not found");
            }

            return books;
        }
    }
}
