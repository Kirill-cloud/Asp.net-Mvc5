using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Data.Entity;

namespace WebApplication1.Controllers
{
    public class HistoryController : Controller
    {
        BookContext db = new BookContext();

        [HttpGet]
        public ActionResult Check() 
        {
            return View("CheckInput");
        }
        [HttpPost] 
        public ActionResult Check(string Name) 
        {
            IEnumerable<Purchase> x = db.Purchases.Where(y => y.Person == Name);

            IEnumerable<Book> books = from Book in db.Books
                                      from Purchase in x
                                      where Book.Id == Purchase.BookId
                                      select Book;
            ViewBag.UserName = Name;
            ViewBag.B = books;
            return View();
        }
    }
}