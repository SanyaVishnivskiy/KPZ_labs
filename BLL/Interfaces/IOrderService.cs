using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IOrderService
    {
        void CreateOrder(Book book, DateTime startReservation);
        void CloseOrder(int orderId, DateTime FinishTime);
        Order GetOrderById(int orderId);
        IEnumerable<Order> GetAllOrders();
        IEnumerable<Book> SearchBookByTitle(string keyTitle);
        IEnumerable<Book> SearchBookByAuthor(string keyAuthor);
        IEnumerable<Book> SearchBookByYear(int keyYear);
        IEnumerable<Book> SearchBookByTag(Tag keyTag);
    }

   
}
