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

            Menu menu = new Menu(new LibraryContext(options));
            menu.MainOperation();
        }
    }
}
