using LibrarieDigitala.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrarieDigitala
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private BooksDbContext db = new BooksDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.IsPostBack)
            {
                BooksDbContext entities = new BooksDbContext();
                var details = (from p in entities.Book
                               join c in entities.Book_Orders
                                   on p.Book_id equals c.Fk_book_id
                               orderby p.Book_id
                               select new
                               {
                                   Book_id = p.Book_id,
                                   Title = p.Title,
                                   Publishing_house = p.Publishing_house,
                                   Publishing_date = p.Publishing_date,
                                   Price = p.Price,
                                   No_pages = p.No_pages,
                                   Description = p.Description,
                                   Fk_book_id = c.Fk_book_id
                               }).Take(5).ToList();
                grid2.DataSource = details;
                grid2.DataBind();

                                     

                                  
                              
            }
        }
    }
}