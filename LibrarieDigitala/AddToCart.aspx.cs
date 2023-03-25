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
    public partial class AddToCart : System.Web.UI.Page
    {
        private BooksDbContext db = new BooksDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //setez in bookId ID-ul cartii extras din query string
                int bookId = Convert.ToInt32(Request.QueryString["book_id"]);

                //apelez metoda de adaugare a produselor in cos
                AddCartItem_Click1();

                BindGridCartList();

                //setez in lista cartItems o lista cu toate obiectele din CartItem care au acelasi ID cu bookId
                List<CartItem> cartItems = (from a in db.CartItem
                                            where a.ID == bookId
                                            select a).ToList();

                //apelez metoda unde se face suma produselor din cos
                SumaCos(cartItems);
            }

        }

        protected void AddCartItem_Click1()
        {
            //setez in bookId ID-ul cartii extras din query string
            int bookId = Convert.ToInt32(Request.QueryString["book_id"]);

            using (var ctx = new BooksDbContext())
            {
                //setez in book obiectul din baza de date Book care are acelasi ID cu bookId
                var book = (from b in ctx.Book
                            where b.Book_id == bookId
                            select b).FirstOrDefault();

                //setez in cart obiectul din baza de date CartItem care are acelasi Id cu bookId
                var cart = (from a in ctx.CartItem
                            where a.Title == book.Title
                            select a).FirstOrDefault();

                //verific daca cartea exista sau nu in cos
                //daca nu exista, o adaug in cos 
                if (cart == null)
                {
                    CartItem cartItem = new CartItem
                    {
                        Title = book.Title,
                        Publishing_house = book.Publishing_house,
                        Price = book.Price,
                        Cantitate = 1,
                        BookId = book.Book_id,
                    };

                    ctx.CartItem.Add(cartItem);

                }

                //daca exista se mareste cantitatea
                else
                {
                    cart.Cantitate++;
                }

                //se salveaza modificarile 
                ctx.SaveChanges();
            }
        }

        //calculeaza suma tutoror elementelor din cos 
        public decimal SumaCos(List<CartItem> cartItems)
        //            decimal total = SumaCos(db.CartItem.ToList());

        {
            //declar o variabila de tip decimal si ii asignez valoarea 0
            decimal? total = decimal.Zero;

            var cartItem = (from a in db.CartItem
                            select a).ToList();

            //calculez totalul produselor din cos inmultind pretul cu cantitatea
            foreach (var item in cartItem)
            {
                total += item.Price * item.Cantitate;
            }

            lblTotal.Text = total.ToString();

            //returnez totalul cosului
            return total ?? decimal.Zero;
        }

        protected void CartList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //setez in bookid ID-ul cartii extras de pe rand din grid
            int bookid = Convert.ToInt32(CartList.DataKeys[e.RowIndex].Values[0]);

            //preia din baza de date cartea care are acelasi ID cu id-ul retinut in obiectul bookid
            var cart = (from a in db.CartItem
                        where a.ID == bookid
                        select a).FirstOrDefault();

            //verificam daca cartea exista in CartList
            if (cart == null)
            {
                Label1.Text = "Cartea nu poate fi stearsa, deoarece ea nu se regaseste in cosul de cumparaturi";
            }

            else
            {
                //verificam daca cantatitatea este mai mare decat 1 
                if (cart.Cantitate > 1)
                {
                    //scadem din cantitate 
                    cart.Cantitate--;

                    //salvam datele
                    db.SaveChanges();
                }

                //daca cantitatea este egala cu 1 
                else
                {
                    //stergem obiectul din baza de date
                    db.CartItem.Remove(cart);

                    //salvam datele
                    db.SaveChanges();
                    Label1.Text = "Cartea a fost stearsa";
                }

                this.BindGridCartList();
            }

            decimal total = SumaCos(db.CartItem.ToList());
            lblTotal.Text = total.ToString();
        }

        private void BindGridCartList()
        {
            //setez in cart o lista cu toate elementele din baza de date CartItem
            var cart = db.CartItem.ToList();

            //mapez datele pe gridul CartList
            CartList.DataSource = cart;
            CartList.DataBind();
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            //pentru fiecare rand din CartList
            foreach (GridViewRow row in CartList.Rows)
            {
                //ii asignez lui bookId, id-ul obiectului de pe rand
                int cartitemid = Convert.ToInt32(CartList.DataKeys[row.RowIndex].Values[0]);

                //preia cantitatea de pe rand si o transforma in textbox
                TextBox quantity = (TextBox)row.FindControl("quantity");

                //preia din baza de date cartea care are acelasi ID cu id-ul retinut in obiectul bookid
                var cartItemextras = (from cartItem in db.CartItem
                            where cartItem.ID == cartitemid
                            select cartItem).FirstOrDefault();

                //verificam daca cartea exista in baza de date
                if (cartItemextras != null)
                {
                    cartItemextras.Cantitate = Convert.ToInt32(quantity.Text);
                    db.SaveChanges();
                }

                else
                {
                    Label1.Text = "Cartea nu exista in baza de date.";
                }
            }
            this.BindGridCartList();

            //calculam suma cosului de cumparaturi si o afisam
            decimal total = SumaCos(db.CartItem.ToList());
            lblTotal.Text = total.ToString();
        }

        protected void DeleteElemets_Click(object sender, EventArgs e)
        {
         
                //preia in bookid id-ul obiectului aflat pe pozitia i
                //int bookid = Convert.ToInt32(CartList.DataKeys[i].Values[0]);

                //preia din baza de date cartea care are acelasi ID cu id-ul retinut in obiectul bookid
                var cartItem = (from a in db.CartItem
                           
                            select a).FirstOrDefault();

                //verificam daca cartea exista sau nu in baza
                if (cartItem != null)
                {
                    db.CartItem.Remove(cartItem);
                    db.SaveChanges();
                
                }

                
                else
                {
                    Label1.Text = "Cartea nu exista";
                }

            this.BindGridCartList();
            decimal total = SumaCos(db.CartItem.ToList());
            lblTotal.Text = total.ToString();
        }

       


        
    }
}