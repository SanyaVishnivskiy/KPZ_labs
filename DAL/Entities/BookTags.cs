using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    /// <summary>
    /// Містить властивості для зв'язування книг та тегів  
    /// </summary>
    public class BookTags
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
