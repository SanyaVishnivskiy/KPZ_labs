﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using DAL.EF;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using MVC.Models;

namespace MVC.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger<BooksController> _logger;
        public BooksController(LibraryContext context,IMapper _mapper, ILogger<BooksController> logger)
        {
            this._db = context;
            this._mapper = _mapper;
            this._logger = logger;
        }

        // GET: Books
        [ActionName("Index")]
        public async Task<ActionResult> Index()
        {
            _logger.LogInformation("Openning Index Page");
            try
            {
                var list = await _db.Books.ToListAsync();
                return View(_mapper.Map<IEnumerable<BookModel>>(list));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception in Index page");
                return View();
            }
            finally {
                _logger.LogInformation("Index finished");
            }
        }

        [ActionName("Get")]
        public ActionResult Get(int id) {
            _logger.LogInformation("Get method action starts",id);
            var book = GetBookWithTags(id);
            if (book != null)
            {
                try
                {
                    return View(book);
                }
                finally {
                    _logger.LogInformation("Get method action successfully finished",);
                }
            }
            else {
                _logger.LogError("Book with such id doesn't exist");
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
            try
            {
                _logger.LogInformation("Create action method starts");
                var tags = _mapper.Map<IEnumerable<TagModel>>(_db.Tags);
                var book = new BookModel { Tags = tags.ToList() };
                return View(book);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception in Create action");
                return RedirectToAction("Index");
            }
            finally {
                _logger.LogInformation("Create action method finished");
            }
        }

        [HttpGet]

        public ActionResult Update(int id) {
            try
            {
                _logger.LogInformation("Update method action starts", id);
                var book = GetBookWithTags(id);
                if (book == null)
                {
                    throw new NullReferenceException("There isn't book with such id");
                }
                var bookTags = book.Tags;
                var tags = _mapper.Map<List<TagModel>>(_db.Tags);
                book.Tags = tags;
                for (int i = 0; i < tags.Count; i++)
                {
                    if (bookTags.Select(x => x.Id).Contains(tags[i].Id))
                    {
                        book.Tags[i].Checked = true;
                    }
                }
                return View(book);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception in Create action");
                return RedirectToAction("Index");
            }
            finally {
                _logger.LogInformation("Update method action finished", id);
            }
        }

        // POST: Books/Create
        [HttpPost]
        public async Task<ActionResult> Create(BookModel book)
        {
            try
            {
                _logger.LogInformation("Create post method starts", JsonSerializer.Serialize(book));
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
                _logger.LogError(e,"Exception in Create post method");
                return View("Views/Shared/Error.cshtml");
            }
            finally
            {
                _logger.LogInformation("Create post method finished");
            }
        }

        // POST: Books/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(BookModel book)
        {
            try
            {
                _logger.LogInformation("Edit post method starts", JsonSerializer.Serialize(book));
                var bookFromBd = _db.Books.Include(x => x.BookTags)
                    .Single(x => x.Id == book.Id);
                if (bookFromBd == null) 
                {
                    throw new NullReferenceException("There isn't such book");
                }
                var tags = book.Tags
                    .Where(x => x.Checked == true)
                    .Select(y => new BookTags { TagId = y.Id, BookId = book.Id })
                    .ToList();
                for (int i = 0; i < bookFromBd.BookTags.Count(); i++)
                {
                    if (!book.Tags
                        .Where(x => x.Checked)
                        .Select(x => x.Id)
                        .Contains(bookFromBd.BookTags.ToList()[i].TagId))
                    {
                        bookFromBd.BookTags.Remove(bookFromBd.BookTags.ToList()[i]);
                    }
                }
                for (int i = 0; i < tags.Count(); i++)
                {
                    if (!bookFromBd.BookTags.Select(x => x.TagId).Contains(tags[i].TagId))
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
            catch (Exception e)
            {
                _logger.LogError(e,"Exception in edit post method",JsonSerializer.Serialize(book));
                return View("Views/Books/Update.cshtml");
            }
            finally {
                _logger.LogInformation("Edit post method finished");
            }
        }

        // POST: Books/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("Delete post method starts", id);
                var book = await _db.Books.FindAsync(id);
                if (book == null)
                {
                    throw new NullReferenceException("There isn't such book");
                }
                _db.Books.Remove(book);
                await _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                _logger.LogError(e, "Exception in delete post method");
                return View();
            }
            finally {
                _logger.LogInformation("Delete post method finished");
            }
        }
    }
}