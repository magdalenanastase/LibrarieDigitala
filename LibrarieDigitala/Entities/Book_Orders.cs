using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibrarieDigitala.Entities
{
    public class Book_Orders
    {
        [Key]
        public int Fk_book_id { get; set; }
        public int Fk_order_id { get; set; }

        public static List<Book_Orders> getbookorders()
        {
            List<Book_Orders> list = new List<Book_Orders>();
            list.Add(new Book_Orders
                {
                    Fk_book_id = 1,
                    Fk_order_id = 201
                });
            return list;
             
        }
    }
}