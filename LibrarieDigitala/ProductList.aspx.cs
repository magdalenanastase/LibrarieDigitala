using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibrarieDigitala.Models;
using System.Web.ModelBinding;
using LibrarieDigitala.Entities;

namespace LibrarieDigitala
{
    public partial class ProductList : System.Web.UI.Page
    {
        private BooksDbContext db = new BooksDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            using (var db = new BooksDbContext())
            {
                var books = db.Book.ToList();
                lista_carti.DataSource = books;
                lista_carti.DataBind();
            }
        }

        protected void lista_carti_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                int bookId = Convert.ToInt32(e.CommandArgument);

                Response.Redirect("ProductDetails.aspx?book_id=" + bookId);
            }
        }

        protected void SortByPriceButton_Click(object sender, EventArgs e)
        {
            var DataSortLowToPrice = (from a in db.Book 
                                      orderby a.Price select a).ToList();
            lista_carti.DataSource = DataSortLowToPrice;
            lista_carti.DataBind();
        }

        protected void SortByPriceDescendingButton_Click(object sender, EventArgs e)
        {
            var DataSortHighToPrice = db.Book.OrderByDescending(b => b.Price).ToList();
            lista_carti.DataSource = DataSortHighToPrice;
            lista_carti.DataBind();
        }
    }
}


