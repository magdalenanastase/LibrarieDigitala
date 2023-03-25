using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibrarieDigitala.Entities
{
    public class Orders
    {
        [Key]
        public int Order_id { get; set; }
        public string Delivery_address { get; set; }
        public string Payment_method { get; set; }
        public int Fk_customer_id { get; set; }

    }
}