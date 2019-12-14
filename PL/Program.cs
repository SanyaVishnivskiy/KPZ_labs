using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;

namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {
            DbContextOptionsBuilder<LibraryContext> qwe = new DbContextOptionsBuilder<LibraryContext>();
            var options = qwe.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LibraryDb;Trusted_Connection=True;MultipleActiveResultSets=true").Options;
            IMenu menu = new Menu(new LibraryContext(options));
            IMenu menu1 = new RUMenu(new LibraryContext(options));
            Console.WriteLine("Choose your language: " +
                                "\n1. Russian" +
                                "\n2. English");
            char command = Console.ReadKey().KeyChar;
            if (command == '1')
            {
                menu1.MainOperation();
            }
            else if (command == '2')
            {
                menu.MainOperation();
            }
        }
    }
}
