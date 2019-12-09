using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    /// <summary>
    /// Містить властивості для зберігання інформації про книгу
    /// </summary>
    public class BookModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int Year { get; set; }
        public List<TagModel> Tags{get;set;}
    }
}
