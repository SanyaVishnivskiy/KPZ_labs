using System.Collections.Generic;
using DAL.Entities;

namespace PL
{
    public interface IMenu
    {
        void CloseOrder();
        void CreateOrder();
        void MainOperation();
        void SearchByAuthor();
        void SearchByTag();
        void SearchByTitle();
        void SearchByYear();
        void ShowAllBook();
        void ShowAllOrders();
        void ShowBooks(IEnumerable<Book> books);
        void ShowMainMenu();
        void ShowOrderMenu();
        void ShowSearchMenu();
    }
}