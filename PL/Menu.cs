using BLL.Interfaces;
using BLL.Services;
using DAL.EF;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PL
{
    public class Menu
    {
        private readonly IBookService bookService;

        private readonly IOrderService orderService;

        public Menu(LibraryContext context)
        {
            bookService = new BookService(context);
            orderService = new OrderService(context);
        }

        public void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Search\n" +
                              "2. Order\n");
        }

        public void ShowSearchMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Search by title\n" +
                              "2. Search by author\n"+
                              "3. Search by year\n"+
                              "4. Search by tag\n");
        }

        public void ShowOrderMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Create order\n" +
                              "2. Close order\n" +
                              "3. Show all orders\n");
        }

        public void MainOperation()
        {
            while (true)
            {
                ShowMainMenu();
                char command = Console.ReadKey().KeyChar;
                if(command == '1')
                {
                    ShowSearchMenu();
                    command = Console.ReadKey().KeyChar;

                    if(command == '1')
                    {
                        SearchByTitle();
                    }
                    else if (command == '2')
                    {
                        SearchByAuthor();
                    }
                    else if (command == '3')
                    {
                        SearchByYear();
                    }
                    else if (command == '4')
                    {
                        SearchByTag();
                    }
                    Console.ReadKey();
                }
                else if(command == '2')
                {
                    ShowOrderMenu();
                    command = Console.ReadKey().KeyChar;

                    if(command == '1')
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


        public void CreateOrder()
        {
            ShowAllBook();
            Console.WriteLine("Choose a book");
            int id = Convert.ToInt32(Console.ReadLine());
            Book book = bookService.GetBookById(id);

            orderService.CreateOrder(book, DateTime.Now);

        }

        public void CloseOrder()
        {
            ShowAllOrders();
            Console.WriteLine("Choose an order");
            int id = Convert.ToInt32(Console.ReadLine());
            orderService.CloseOrder(id, new DateTime(2019, 12, 10));
        }

        public void ShowAllOrders()
        {
            var orders = orderService.GetAllOrders();
            foreach (Order order in orders)
            {
                int day = (order.FinishReservation - order.StartReservation).Days;
                if (order.IsClose)
                {
                    Console.WriteLine("Id: " + order.Id + ", StartReservation: " + order.StartReservation + ", FinishReservation: " + order.FinishReservation + ", Title: " + order.Book.Name + ", for: " + day + " days");
                }
                else
                {
                    Console.WriteLine("Id: " + order.Id + ", StartReservation: " + order.StartReservation + ", Title: " + order.Book.Name);
                }
            }
        }
        public void ShowAllBook()
        {
            var books = bookService.GetAllBook();
            foreach (Book book in books)
            {
                Console.WriteLine("Id: " + book.Id + ", Title: " + book.Name + ", year: " + book.Year + ", amount: " + book.Amount + ", tag: ");// + book.BookTags.Where(x => x.BookId == book.Id));
            }
        }
        public void SearchByTitle()
        {
            Console.WriteLine("Enter title: ");
            string keyTitle = Console.ReadLine();
            var books = bookService.SearchBookByTitle(keyTitle);

            if (books.Count() == 0)
            {
                Console.WriteLine("There are not such books");
            }
            else
            {
                ShowBooks(books);
            }
        }

        public void SearchByYear()
        {
            Console.WriteLine("Enter year: ");
            int keyYear = Convert.ToInt32(Console.ReadLine());
            var books = bookService.SearchBookByYear(keyYear);

            if (books == null)
            {
                Console.WriteLine("There are not such books");
            }
            else
            {
                ShowBooks(books);
            }
        }

        public void SearchByAuthor()
        {
            Console.WriteLine("Enter author: ");
            string keyAuthor = Console.ReadLine();
            var books = bookService.SearchBookByAuthor(keyAuthor);

            if (books == null)
            {
                Console.WriteLine("There are not such books");
            }
            else
            {
                ShowBooks(books);
            }
        }

        public void SearchByTag()
        {
            Console.WriteLine("Enter tag: ");
            string keyTag = Console.ReadLine();
            var books = bookService.SearchBookByTitle(keyTag);

            if (books == null)
            {
                Console.WriteLine("There are not such books");
            }
            else
            {
                ShowBooks(books);
            }
        }

        public void ShowBooks(IEnumerable<Book> books)
        {
            foreach(Book book in books)
            {
                Console.WriteLine("Id: " + book.Id + ", Title: " + book.Name + ", year: " + book.Year + ", amount: " + book.Amount + ", tag: ");// + book.BookTags.Where(x => x.BookId == book.Id));
            }
        }


    }
}
