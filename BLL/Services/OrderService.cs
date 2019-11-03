using BLL.Interfaces;
using DAL.EF;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly LibraryContext context;
        public OrderService(LibraryContext context)
        {
            this.context = context;
        }

        public void CreateOrder(Book book, DateTime startReservation)
        {
            Order newOrder = new Order()
            {
                Book = book,
                StartReservation = startReservation,
                IsClose = false,
            };

            context.Add(newOrder);
            context.SaveChanges();
        }

        public void CloseOrder(int orderId, DateTime FinishTime)
        {
            Order order = context.Orders.Find(orderId);

            if(order == null)
            {
                throw new Exception("There are not such order");
            }

            if (order.IsClose)
            {
                throw new Exception("Order are alreasy closed");
            }

            order.FinishReservation = FinishTime;
            order.IsClose = true;

            context.Orders.Update(order);
            context.SaveChanges();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return context.Orders.ToList();
        }

        public Order GetOrderById(int orderId)
        {
            return context.Orders.Find(orderId);
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
}
