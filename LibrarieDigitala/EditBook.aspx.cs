using LibrarieDigitala.Entities;
using LibrarieDigitala.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrarieDigitala
{
    public partial class EditBook : System.Web.UI.Page
    {
        private BooksDbContext db = new BooksDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //apelez metoda Verificare pentru a se face o verificare asupra cartii la intrarea in pagina
                Verificare();
            }
        }


        //metoda prin care se face verificarea daca obiectulul exista in baza si daca se afla pe o comanda sau nu
        protected void Verificare()
        {
            try
            {

                //setez in bookid ID-ul cartii extras din query string
                int bookid = Convert.ToInt32(Request.QueryString["Book_id"]);

                //preia din baza de date cartea care are acelasi ID cu id-ul retinut in obiectul bookid
                var book = (from b in db.Book
                            where b.Book_id == bookid
                            select b).FirstOrDefault();


                //extrag cartea din book_orders care are acelasi ID cu bookid si o asignez lui CarteComanda 
                var CarteComanda = (from a in db.Book_Orders
                                    where a.Fk_book_id == bookid
                                    select a).FirstOrDefault();

                if (book == null)
                {
                    Label2.Text = "Cartea nu se regaseste in baza de date.";
                    TextBoxDisabled();
                }

                else if (CarteComanda == null)
                {
                    UpdateTitle.Text = book.Title;
                    UpdatePublishing_House.Text = book.Publishing_house;
                    UpdateData.Text = Convert.ToString(book.Publishing_date);
                    UpdatePrice.Text = book.Price.ToString();
                    UpdateNoPages.Text = book.No_pages.ToString();
                    UpdateDescription.Text = book.Description.ToString();
                    Label2.Text = "Aceastea sunt informatiile despre cartea selectata!";
                }

                else
                {
                    TextBoxDisabled();
                    Label2.Text = "Cartea apartine cel putin unei comenzi, deci nu poate fi editata!";
                }
            }

            catch (Exception ex)
            {
                Label2.Text = "Valoarea id-ului nu este valida." + ex.Message;
                TextBoxDisabled();

            }
        }



        //o metoda prin care controalele de tip textbox devin disable si butonul devine disable
        protected void TextBoxDisabled()
        {
            UpdateBook.Enabled = false;
            UpdateTitle.Enabled = false;
            UpdatePublishing_House.Enabled = false;
            UpdateData.Enabled = false;
            UpdatePrice.Enabled = false;
            UpdateNoPages.Enabled = false;
            UpdatePrice.Enabled = false;
            UpdateDescription.Enabled = false;
        }


        protected void editbook(object Sender, EventArgs e)
        {

            int bookid = Convert.ToInt32(Request.QueryString["Book_id"]);

            var book = (from bk in db.Book
                        where bk.Book_id == bookid
                        select bk).FirstOrDefault();

            var CarteComanda = (from c in db.Book_Orders
                                where c.Fk_book_id == bookid
                                select c).FirstOrDefault();
            if (book == null)
            {
                Label2.Text = "Cartea nu mai poate fi modificata. Ea a fost stearsa!";
                TextBoxDisabled();
            }

            else if (CarteComanda != null)
            {

                Label2.Text = "Cartea nu mai poate fi modificata. Ea apartine unei comenzi";
                TextBoxDisabled();

            }

            else
            {
                using (var context = new BooksDbContext())
                {
                    //populeaza proprietatile obiectului book cu informatiile din controalele din interfata
                    {
                        book.Title = UpdateTitle.Text;
                        book.Publishing_house = UpdatePublishing_House.Text;
                        book.Publishing_date = DateTime.Parse(UpdateData.Text);
                        book.Price = Convert.ToDecimal(UpdatePrice.Text);
                        book.No_pages = Convert.ToInt32(UpdateNoPages.Text);
                        book.Description = UpdateDescription.Text;
                    }

                    //se realizeaza update-ul
                    context.Entry(book).State = System.Data.Entity.EntityState.Modified;

                    //se salveaza modificarile
                    context.SaveChanges();
                }
            }
        }
    }
}