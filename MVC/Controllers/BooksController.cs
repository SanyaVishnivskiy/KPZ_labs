using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.EF;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MVC.Models;

namespace MVC.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryContext _db;
        private readonly IMapper _mapper;
        public BooksController(LibraryContext context,IMapper _mapper)
        {
            this._db = context;
            this._mapper = _mapper;
        }

        // GET: Books
        [ActionName("Index")]
        public async Task<ActionResult> Index()
        {
            var list = await _db.Books.ToListAsync();
            return View(_mapper.Map<IEnumerable<BookModel>>(list));
        }

        [ActionName("Get")]
        public ActionResult Get(int id) {
            var book = GetBookWithTags(id);
            if (book != null)
            {
                return View(book);
            }
            else {
                return RedirectToAction("Index");
            }
        }

        private BookModel GetBookWithTags(int id) {
            var book = _db.Books.Single(x=>x.Id == id);
            book.BookTags = _db.Entry(book).Collection(x=>x.BookTags).Query().ToList();
            var mappedBook = _mapper.Map<BookModel>(book);
            var tags = _db.Tags.AsQueryable();
            mappedBook.Tags = book.BookTags.Join(tags, x => x.TagId, y => y.Id, (x, y) => new TagModel { Id = y.Id, Name = y.Name }).ToList();
            return mappedBook;
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            var tags = _mapper.Map<IEnumerable<TagModel>>(_db.Tags);
            var book = new BookModel { Tags = tags.ToList()};
            return View(book);
        }
        [HttpGet]

        public ActionResult Update(int id) {
            var book = GetBookWithTags(id);
            var bookTags = book.Tags;
            var tags = _mapper.Map<List<TagModel>>(_db.Tags);
            book.Tags = tags;
            for(int i = 0; i < tags.Count; i++) {
                if (bookTags.Select(x=>x.Id).Contains(tags[i].Id)) {
                    book.Tags[i].Checked = true;
                }
            }
            return View(book);
        }

        // POST: Books/Create
        [HttpPost]
        public async Task<ActionResult> Create(BookModel book)
        {
            try
            {
                var item = _mapper.Map<Book>(book);
                var tags = book.Tags;
                item.BookTags = tags
                    .Where(x => x.Checked == true)
                    .Select(y => new BookTags { TagId = y.Id, Book = item, BookId = item.Id })
                    .ToList();
                await _db.Books.AddAsync(item);
                await _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // POST: Books/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(BookModel book)
        {
            try
            {
                var bookFromBd = _db.Books.Include(x=>x.BookTags)
                    .Single(x=>x.Id == book.Id);
                var tags = book.Tags
                    .Where(x => x.Checked == true)
                    .Select(y => new BookTags { TagId = y.Id, BookId = book.Id })
                    .ToList();
                for (int i = 0; i < bookFromBd.BookTags.Count(); i++) 
                {
                    if (!book.Tags
                        .Where(x=>x.Checked)
                        .Select(x => x.Id)
                        .Contains(bookFromBd.BookTags.ToList()[i].TagId)) 
                    {
                        bookFromBd.BookTags.Remove(bookFromBd.BookTags.ToList()[i]);
                    }
                }
                for (int i = 0; i < tags.Count(); i++) 
                {
                    if (!bookFromBd.BookTags.Select(x=>x.TagId).Contains(tags[i].TagId)) 
                    {
                        bookFromBd.BookTags.Add(tags[i]);
                    }
                }
                bookFromBd.Name = book.Name;
                bookFromBd.Amount = book.Amount;
                _db.Books.Update(bookFromBd);
                await _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View("Views/Books/Update.cshtml");
            }
        }

        // POST: Books/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var book = await _db.Books.FindAsync(id);
                _db.Books.Remove(book);
                await _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}