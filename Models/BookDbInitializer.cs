using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace BookStoreMVC.Models
{
    public class BookDbInitializer : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext db)
        {
            db.Books.Add(new Book { Name = "Война и мир", Author = "Л. Толстой", Price = 220 ,Image= "../Content/Images/m.jpg" });
            db.Books.Add(new Book { Name = "Отцы и дети", Author = "И. Тургенев", Price = 180, Image = "../Content/Images/m.jpg" });
            db.Books.Add(new Book { Name = "Чайка", Author = "А. Чехов", Price = 150, Image = "../Content/Images/m.jpg" });

            base.Seed(db);
        }
    }
}