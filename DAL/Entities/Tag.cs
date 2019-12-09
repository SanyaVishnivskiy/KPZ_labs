using System.Collections.Generic;

namespace DAL.Entities
{
    /// <summary>
    /// Містить властивості для зберігання інформації про тег
    /// </summary>
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BookTags> BookTags { get; set; }
    }
}