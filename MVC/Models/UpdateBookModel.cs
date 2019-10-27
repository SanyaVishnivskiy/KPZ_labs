using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class UpdateBookModel
    {
        public BookModel Book { get; set; }
        public List<TagModel> AllTags { get; set; }
    }
}
