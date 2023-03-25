using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibrarieDigitala.Entities
{
    public class Book
    {    
        [Key]
        public int Book_id { get; set; }
        public string Title { get; set; }
        public string Publishing_house { get; set; }
        public DateTime? Publishing_date { get; set; }
        public Decimal? Price { get; set; }
        public int No_pages { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public IList<Author_Book> AuthorBooks { get; set; }
    }


}