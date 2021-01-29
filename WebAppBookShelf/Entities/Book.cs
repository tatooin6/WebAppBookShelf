using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppBookShelf.Entities
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int PageCount { get; set; }

        public string Cover { get; set; }

        public DateTime PublishedDate { get; set; }

        public List<Author> Authors { get; set; }
    }
}
