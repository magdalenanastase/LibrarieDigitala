using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrarieDigitala.Entities
{
    public class Author_Book
    {
        public int Fk_author_id { get; set; }
        public int Fk_book_id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public Authors Author { get; set; }
    }
}