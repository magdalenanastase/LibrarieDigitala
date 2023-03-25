using LibrarieDigitala.Entities;
using LibrarieDigitala.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrarieDigitala
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        private BooksDbContext db = new BooksDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int bookId;

                if (int.TryParse(Request.QueryString["book_id"], out bookId))
                {
                    var book = (from a in db.Book
                                where a.Book_id == bookId
                                select a).FirstOrDefault();

                    if (book != null)
                    {
                        form1.DataSource = new[] { book };
                        form1.DataBind();
                    }

                    else
                    {
                        detaliicarte.Text = "Cartea nu exista in baza de date";
                        //Response.Redirect("ProductList.aspx");
                    }

                }

                else
                {
                    //Response.Redirect("ProductList.aspx");
                    detaliicarte.Text = "Cartea nu exista in baza de date";

                }
            }
        }
    }
}


      