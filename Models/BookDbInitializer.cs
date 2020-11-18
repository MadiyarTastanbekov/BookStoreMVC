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
            db.Books.Add(new Book { Name = "Абай жолы", Author = "М Ауезов", Price = 1200, Image = @"D:\BookStoreMVC\Content\Images\m.jpg" });
            db.Books.Add(new Book { Name = "Original MSSQL", Author = "Microsoft company", Price = 18000, Image = "../Content/Images/m.jpg" });
            db.Books.Add(new Book { Name = "Design Patterns: Elements of Reusable Object - Oriented Software", Author = "Э. Гамма Р. Хелм Р. Джонсон Дж. Влиссидес", Price = 25000, Image = "../Content/Images/m.jpg" });

            base.Seed(db);
        }
    }
}