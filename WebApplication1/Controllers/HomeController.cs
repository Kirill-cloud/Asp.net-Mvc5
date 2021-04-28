using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        BookContext bd = new BookContext();
        public ActionResult Index()
        {
            IEnumerable <Book> books = bd.Books;

            ViewBag.Books = books;

            return View();
        }
        [HttpGet]
        public ActionResult Buy(int id) 
        {
            ViewBag.BookId=id;
            return View();
        }
        [HttpPost]
        public ActionResult Buy(Purchase purchase) 
        {
            purchase.PurchaseDate = DateTime.Now;
            bd.Purchases.Add(purchase);
            bd.SaveChanges();
            return RedirectToAction("Check", "History");
        }
    }
}