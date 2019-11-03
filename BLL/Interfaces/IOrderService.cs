using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IOrderService
    {
        void CreateOrder(Book book, DateTime startReservation);
        IEnumerable<Book> SearchBook();
    }
}
