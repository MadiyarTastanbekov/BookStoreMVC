using BookStoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BookStoreMVC.Util;
using System.Linq;
using System.Data.Entity;

namespace BookStoreMVC.Controllers
{
    public class HomeController : Controller
    {
       public BookContext db = new BookContext();
        public ActionResult Index()
        {
            IEnumerable<Book> books = db.Books;
            ViewBag.BS = books;

            return View(books);
        }
       
        [HttpGet]
        public ActionResult Buy(int? id)
        {
            if (id > 3)
            {
                return new HttpUnauthorizedResult();
            }
            ViewBag.BookId = id ?? 0;
            return View();
        }
        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.DateTime = DateTime.Now;
            db.Purchases.Add(purchase);
            db.SaveChanges();
            return "Thank you " + purchase.Person + ", what bought book \n" + "Date bought:" + purchase.DateTime;
        }
        /// <summary>
        /// Приватных методов метод действий не бывает 
        /// </summary>
        /// <returns></returns>
        private DateTime Time()
        {
            return DateTime.Now;
        }
        public FileResult Abaijoli(int id)
        {
            if (id == 1)
            {
                string image = @"D:/BookStoreMVC/Files/Абай жолы. І кітап.pdf";
                string file_type_Abai = "application/pdf";
                return File(image, file_type_Abai);
            }
            if (id == 2)
            {
                string image = @"D:/BookStoreMVC/Files/original MSSQL.pdf";
                string file_type_Abai = "application/pdf";
                return File(image, file_type_Abai);
            }
            if (id == 3)
            {
                string image = @"D:/BookStoreMVC/Files/Pattern.pdf";
                string file_type_Abai = "application/pdf";
                return File(image, file_type_Abai);
            }
            string image1 = @"D:/BookStoreMVC/Files/Абай жолы. І кітап.pdf";
            string file_type_Abai2 = "application/pdf";
            return File(image1, file_type_Abai2);
        }

        public ActionResult GetList()
        {
            string[] states = { "Kazakhstan","Russia","Canada" };
            return PartialView(states);
        }
       public ActionResult Views(int? id)
        {
            Book k = db.Books.Find(id);
            if (k == null) return HttpNotFound();
            return View(k);
        }
        [HttpGet]
        public ActionResult EditBook(int? id)
        {
            Book book = db.Books.Find(id);
            if (id != null)
            {
                return View(book);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditBook(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        { 

            return View();
        }
        [HttpPost]
        public ActionResult Create(Book book)
        {
            db.Entry(book).State = EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Book b = db.Books.Find(id);
            if (b == null)
                return HttpNotFound();
            return View(b);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfing(int id)
        {
            Book book = db.Books.Find(id);
            if (book == null) return HttpNotFound();
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #region
        //public string Square(int a, int h)
        //{
        //    double s = a * h / 2.0;
        //    return "<h2>Площадь треугольника с основанием " + a +
        //    " и высотой " + h + " равна " + s + "</h2>";
        //}
        //public string Square1(int a = 10, int h = 5)
        //{
        //    double s = a * h / 2.0;
        //    return "<h2>Площадь треугольника с основанием " + a +
        //    " и высотой " + h + " равна " + s + "</h2>";
        //}
        //public string Square1()
        //{
        //    int a = Int32.Parse(Request.Params["a"]);
        //    int h = Int32.Parse(Request.Params["h"]);
        //    double s = a * h / 2.0;
        //    return "<h2>Площадь треугольника с основанием " + a + " и высотой " + h + " равна " + s + "</h2>";
        //}
        //public ActionResult GetHtml()
        //{
        //    return new HtmlResult("<h2> Hi Madiyar</h2>");
        //}
        //public ActionResult GetImage()
        //{
        //    string path = " ../Images/m1.png";
        //    return new ImageResult(path);
        //}
        //public ViewResult SomeMethod()
        //{
        //    return View("./Views/Home/Index.cshtml");
        //}
        #endregion
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}