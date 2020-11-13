
using System.Data.Entity;

namespace BookStoreMVC.Models
{
    public class BookContext:DbContext 
    {
        public BookContext() : base("BookContext")
        { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}