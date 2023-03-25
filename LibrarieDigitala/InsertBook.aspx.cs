using LibrarieDigitala.Entities;
using LibrarieDigitala.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrarieDigitala
{
    public partial class InsertBook : System.Web.UI.Page
    {
        private BooksDbContext db = new BooksDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            Data.Attributes["max"] = DateTime.Now.ToString("yyyy-MM-dd");
        }

        protected void AddProductButton_Click(object sender, EventArgs e)
        {
            using (var context = new BooksDbContext())
            {
                var std = new Book();
                {
                    std.Title = AddTitle.Text;
                    std.Publishing_house = AddPublishing_House.Text;
                    std.Publishing_date = DateTime.Parse(Data.Text);
                    std.Price = Convert.ToDecimal(AddPrice.Text);
                    std.No_pages = Convert.ToInt16(AddNoPages.Text);
                    std.Description = AddDescription.Text;
                };
                
                if (Request.Files[0] != null)
                {
                    HttpPostedFile file = Request.Files[0];
                    Stream fs = file.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    std.Image = bytes;
                }

                if (Page.IsValid)
                {
                    Label1.Text = "Datele au fost introduse";
                    context.Book.Add(std);
                    context.SaveChanges();

                }
            }
        }
    }
}