using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF
{
    /// <summary>
    /// Контекст бази даних. Містить властивості для взаємодії з таблицями.
    /// </summary>
    public class LibraryContext : DbContext
    { 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options">Налаштування бази даних</param>
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Представляє колекцію книг
        /// </summary>
        public DbSet<Book> Books { get; set; }
        
        /// <summary>
        /// Представляє колекцію тегів
        /// </summary>
        public DbSet<Tag> Tags { get; set; }

        /// <summary>
        /// Представляє проміжну таблицю книг та тегів
        /// </summary>
        public DbSet<BookTags> BookTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookTags>().HasKey(bt=> new { bt.BookId,bt.TagId});
            modelBuilder.Entity<BookTags>()
                .HasOne(x => x.Book)
                .WithMany(y=> y.BookTags)
                .HasForeignKey(z=>z.BookId);
            modelBuilder.Entity<BookTags>()
                .HasOne(x => x.Tag)
                .WithMany(y => y.BookTags)
                .HasForeignKey(z => z.TagId);

            modelBuilder.Entity<Tag>().HasData(
                    new Tag { Id = 1, Name = "Historical"},
                    new Tag { Id = 2, Name = "Science Fiction"},
                    new Tag { Id = 3, Name = "Fairy tails"},
                    new Tag { Id = 4, Name = "Fantastic"},
                    new Tag { Id = 5, Name = "Roman"},
                    new Tag { Id = 6, Name = "Fiction"},
                    new Tag { Id = 7, Name = "Novels"}
                );
        }

    }
}
