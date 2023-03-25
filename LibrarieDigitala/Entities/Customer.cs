using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibrarieDigitala.Entities
{
    public class Customer
    {
        [Key]
        public int Customer_id { get; set; }
        public string Customer_name { get; set; }
        public string Customer_address { get; set; }
        public string Customer_phone { get; set; }
        public string Customer_email { get; set; }


    }
}