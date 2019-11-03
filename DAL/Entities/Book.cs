using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int Year { get; set; }
        public ICollection<BookTags> BookTags { get; set; }
        public virtual IEnumerable<Order> OrderList { get; set; }
    }
}
