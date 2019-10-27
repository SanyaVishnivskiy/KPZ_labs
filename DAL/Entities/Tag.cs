using System.Collections.Generic;

namespace DAL.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BookTags> BookTags { get; set; }
    }
}