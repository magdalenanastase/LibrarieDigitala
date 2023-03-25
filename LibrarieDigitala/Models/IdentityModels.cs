using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Web;
using System;
using LibrarieDigitala.Models;
using System.Data.Entity;
using LibrarieDigitala.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LibrarieDigitala.Models
{
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
    }

    public class BooksDbContext : DbContext //book -numele bazei
    {
        public BooksDbContext() : base("BookConnection")
        {
            
        }

        public System.Data.Entity.DbSet<Book> Book { get; set; }
        public System.Data.Entity.DbSet<Authors> Author { get; set; }
        public System.Data.Entity.DbSet<Author_Book> Author_Book { get; set; }
        public System.Data.Entity.DbSet<Orders> Orders { get; set; }
        public System.Data.Entity.DbSet<Book_Orders> Book_Orders { get; set; }
        public System.Data.Entity.DbSet<CartItem> CartItem { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // definirea relatiei de many to many 
            modelBuilder.Entity<Author_Book>().HasKey(ab => new { ab.Fk_book_id, ab.Fk_author_id });
            modelBuilder.Entity<Author_Book>()
                .HasRequired(bc => bc.Book)
                .WithMany(b => b.AuthorBooks)
                .HasForeignKey(bc => bc.Fk_book_id);
            modelBuilder.Entity<Author_Book>()
                .HasRequired(bc => bc.Book)
                .WithMany(c => c.AuthorBooks)
                .HasForeignKey(bc => bc.Fk_author_id);


            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer<BooksDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }

       
        }
    }

    #region Helpers
    public class UserManager : UserManager<ApplicationUser>
    {
        public UserManager()
            : base(new UserStore<ApplicationUser>(new ApplicationDbContext()))
        {
        }
    }


namespace LibrarieDigitala
{
    public static class IdentityHelper
    {
        // Used for XSRF when linking external logins
        public const string XsrfKey = "XsrfId";

        public static void SignIn(UserManager manager, ApplicationUser user, bool isPersistent)
        {
            IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        public const string ProviderNameKey = "providerName";
        public static string GetProviderNameFromRequest(HttpRequest request)
        {
            return request[ProviderNameKey];
        }

        public static string GetExternalLoginRedirectUrl(string accountProvider)
        {
            return "/Account/RegisterExternalLogin?" + ProviderNameKey + "=" + accountProvider;
        }

        private static bool IsLocalUrl(string url)
        {
            return !string.IsNullOrEmpty(url) && ((url[0] == '/' && (url.Length == 1 || (url[1] != '/' && url[1] != '\\'))) || (url.Length > 1 && url[0] == '~' && url[1] == '/'));
        }

        public static void RedirectToReturnUrl(string returnUrl, HttpResponse response)
        {
            if (!String.IsNullOrEmpty(returnUrl) && IsLocalUrl(returnUrl))
            {
                response.Redirect(returnUrl);
            }
            else
            {
                response.Redirect("~/");
            }
        }
    }
    #endregion
}