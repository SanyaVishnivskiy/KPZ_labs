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
    public class OrderService : IOrderService
    {
        private readonly LibraryContext context;
        public OrderService(LibraryContext context)
        {
            this.context = context;
        }

        public void CreateOrder(Book book, DateTime startReservation)
        {
            if(book == null)
            {
                throw new NotFoundEntityException("Book is not found");
            }

            Order newOrder = new Order()
            {
                BookId = book.Id,
                StartReservation = startReservation,
                IsClose = false,
            };

            context.Orders.Add(newOrder);
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
                throw new Exception("Order are already closed");
            }

            order.FinishReservation = FinishTime;
            order.IsClose = true;

            context.Orders.Update(order);
            context.SaveChanges();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            var orders = context.Orders.ToList();

            if(orders == null)
            {
                throw new NotFoundEntityException("There are empty");
            }

            return context.Orders.ToList();
        }

        public Order GetOrderById(int orderId)
        {
            Order order = context.Orders.Find(orderId);
            
            if(order == null)
            {
                throw new NotFoundEntityException("Order not found");
            }

            return order;
        }

       /* public IEnumerable<Book> SearchBookByAuthor(string keyAuthor)
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
        */
    }
}
