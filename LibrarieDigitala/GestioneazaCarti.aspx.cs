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
    public partial class Gestioneaza_carti : System.Web.UI.Page
    {
        private BooksDbContext db = new BooksDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            //se apeleaza metoda de mapare a datelor pe grid
            BindGrid();

        }

        //o metoda prin care la apasarea butonului "Adauga" redirectioneaza utilizatorul pe pag insert book
        protected void insertredirect(object sender, EventArgs e)
        {
            Response.Redirect("InsertBook.aspx");
        }

       

        //metoda prin care se face maparea datelor pe grid
        private void BindGrid()
        {

            var carti = db.Book.ToList();
            grid1.DataSource = carti;
            grid1.DataBind();
        }

        //metoda de paginare a gridului
        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            grid1.PageIndex = e.NewPageIndex;
            BindGrid();
        }


        protected void grid1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //setez in bookid ID-ul cartii extras de pe rand din grid
            int bookid = Convert.ToInt32(grid1.DataKeys[e.RowIndex].Values[0]);

            //preia din baza de date cartea care are acelasi ID cu id-ul retinut in obiectul bookid
            var book = (from b in db.Book
                        where b.Book_id == bookid
                        select b).FirstOrDefault();

         
            //preia din baza de date Book_Orders cartea cu acelasi ID ca bookid si o asigneaza lui CarteFaraComanda
            var CarteFaraComanda = (from a in db.Book_Orders
                                    where a.Fk_book_id == bookid
                                    select a).FirstOrDefault();

            //verifica daca cartea exista sau nu in baza de date
            if (book == null)
            {
                Label1.Text = "Cartea nu poate fi stearsa, deoarece ea nu exista in baza de date.";
            }

            //verifica daca cartea apartine sau nu unei comenzi
            else if (CarteFaraComanda != null)
            {
                Label1.Text = "Cartea nu poate fi stearsa, deoarece ea apartine unei comenzi.";
            }

            else 
            {
                //stergerea obiectului din tabela Book
                db.Book.Remove(book);

                //salvarea modificarilor
                db.SaveChanges();
                Label1.Text = "Cartea a fost stearsa.";
                this.BindGrid();
            }
        }

    }
}













