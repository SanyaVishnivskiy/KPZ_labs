using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.Exceptions;
using BLL.Interfaces;
using BLL.Services;
using DAL.EF;
using DAL.Entities;
using Microsoft.Extensions.Logging;

namespace PL
{
    public class RUMenu : IMenu
    {
        private readonly IBookService bookService;

        private readonly IOrderService orderService;

        readonly ILogger<Menu> logger;

        public RUMenu(LibraryContext context)
        {
            bookService = new BookService(context);
            orderService = new OrderService(context);
            var loggerFactory = LoggerFactory.Create(builder =>
            { });
            logger = loggerFactory.CreateLogger<Menu>();
        }
        public void CloseOrder()
        {
            ShowAllOrders();
            Console.WriteLine("Закрыть ордер");
            int id = Convert.ToInt32(Console.ReadLine());
            orderService.CloseOrder(id, new DateTime(2019, 12, 10));
        }

        public void CreateOrder()
        {
            ShowAllBook();
            Console.WriteLine("Выберите книгу");
            int id = Convert.ToInt32(Console.ReadLine());
            Book book = bookService.GetBookById(id);

            orderService.CreateOrder(book, DateTime.Now);
        }

        public void MainOperation()
        {
            while (true)
            {
                ShowMainMenu();
                char command = Console.ReadKey().KeyChar;
                if (command == '1')
                {
                    ShowSearchMenu();
                    command = Console.ReadKey().KeyChar;

                    if (command == '1')
                    {
                        try
                        {
                            SearchByTitle();
                        }
                        catch (NotFoundEntityException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    else if (command == '2')
                    {
                        try
                        {
                            SearchByAuthor();
                        }
                        catch (NotFoundEntityException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        SearchByAuthor();
                    }
                    else if (command == '3')
                    {
                        try
                        {
                            SearchByYear();
                        }
                        catch (NotFoundEntityException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        SearchByYear();
                    }
                    else if (command == '4')
                    {
                        try
                        {
                            SearchByTag();
                        }
                        catch (NotFoundEntityException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        SearchByTag();
                    }
                    Console.ReadKey();
                }
                else if (command == '2')
                {
                    ShowOrderMenu();
                    command = Console.ReadKey().KeyChar;

                    if (command == '1')
                    {
                        CreateOrder();
                    }
                    else if (command == '2')
                    {
                        CloseOrder();
                    }
                    else if (command == '3')
                    {
                        ShowAllOrders();
                    }
                    Console.ReadKey();
                }
                else if (command == '0')
                {
                    break;
                }
            }
        }

        public void SearchByAuthor()
        {
            Console.WriteLine("Введите автора: ");
            string keyAuthor = Console.ReadLine();
            var books = bookService.SearchBookByAuthor(keyAuthor);

            if (books.Count() == 0)
            {
                Console.WriteLine("Таких книг нет");
            }
            else
            {
                ShowBooks(books);
            }
        }

        public void SearchByTag()
        {
            Console.WriteLine("Введите тэг: ");
            string keyTag = Console.ReadLine();
            var books = bookService.SearchBookByTitle(keyTag);

            if (books.Count() == 0)
            {
                Console.WriteLine("Таких книг нет");
            }
            else
            {
                ShowBooks(books);
            }
        }

        public void SearchByTitle()
        {
            Console.WriteLine("Введите название: ");
            string keyTitle = Console.ReadLine();
            var books = bookService.SearchBookByTitle(keyTitle);

            if (books.Count() == 0)
            {
                Console.WriteLine("Таких книг нет");
            }
            else
            {
                ShowBooks(books);
            }
        }

        public void SearchByYear()
        {
            Console.WriteLine("Введите год: ");
            int keyYear = Convert.ToInt32(Console.ReadLine());
            var books = bookService.SearchBookByYear(keyYear);

            if (books.Count() == 0)
            {
                Console.WriteLine("There are not such books");
            }
            else
            {
                ShowBooks(books);
            }
        }

        public void ShowAllBook()
        {
            var books = bookService.GetAllBook();
            foreach (Book book in books)
            {
                Console.WriteLine("Id: " + book.Id + ", Название: " + book.Name + ", год: " + book.Year + ", количество: " + book.Amount + ", тэг: ");// + book.BookTags.Where(x => x.BookId == book.Id));
            }
        }

        public void ShowAllOrders()
        {
            var orders = orderService.GetAllOrders();
            foreach (Order order in orders)
            {
                int day = (order.FinishReservation - order.StartReservation).Days;
                if (order.IsClose)
                {
                    Console.WriteLine("Id: " + order.Id + ", Начало резервации: " + order.StartReservation + ", Конец резервации: " + order.FinishReservation + ", Название: " + order.Book?.Name + ", на: " + day + " дней");
                }
                else
                {
                    Console.WriteLine("Id: " + order.Id + ", Начало резервации: " + order.StartReservation + ", Название: " + order.Book?.Name);
                }
            }
        }

        public void ShowBooks(IEnumerable<Book> books)
        {
            foreach (Book book in books)
            {
                Console.WriteLine("Id: " + book.Id + ", Название: " + book.Name + ", год: " + book.Year + ", количество: " + book.Amount + ", тэг: ");// + book.BookTags.Where(x => x.BookId == book.Id));
            }
        }

        public void ShowMainMenu()
        {
            logger.LogDebug($"Show main menu");
            Console.Clear();
            Console.WriteLine("1. Поиск книги\n" +
                              "2. Заказы\n");
        }

        public void ShowOrderMenu()
        {
            logger.LogDebug($"Show order menu");
            Console.Clear();
            Console.WriteLine("1. Создать ордер\n" +
                              "2. Закрыть ордер\n" +
                              "3. Вывести все ордеры\n");
        }

        public void ShowSearchMenu()
        {
            logger.LogDebug($"Show search menu");
            Console.Clear();
            Console.WriteLine("1. Поиск по названию\n" +
                              "2. Поиск по автору\n" +
                              "3. Поиск по году\n" +
                              "4. Поиск по тэгу\n");
        }
    }
}
