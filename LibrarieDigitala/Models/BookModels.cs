using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrarieDigitala.Models
{
    public class BookModels
    {
        public int Book_id { get; set; }
        public string Title { get; set; }
        public string Publishing_house { get; set; }
        public string Publishing_date { get; set; }
        public float Price { get; set; }
        public int No_pages { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}