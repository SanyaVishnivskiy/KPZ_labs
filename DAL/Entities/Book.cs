using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{

    /// <summary>
    /// Містить властивості для зберігання інформації про книгу
    /// </summary>
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int Year { get; set; }

        /// <summary>
        /// Містить колекцію проміжної таблички
        /// </summary>
        public ICollection<BookTags> BookTags { get; set; }
    }
}
