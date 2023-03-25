using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibrarieDigitala.Entities
{
    public class CartItem
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Publishing_house { get; set; }
        public Decimal? Price { get; set; }
        public int Cantitate { get; set; }
        public int BookId { get; set; }

    }
}