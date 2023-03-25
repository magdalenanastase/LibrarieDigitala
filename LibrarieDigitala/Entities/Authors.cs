using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibrarieDigitala.Entities
{
    public class Authors
    {    
        [Key]
        public int Author_id { get; set; }
        public string Author_name { get; set; }
        public IList<Author_Book> AuthorBooks { get; set; }
    }
}