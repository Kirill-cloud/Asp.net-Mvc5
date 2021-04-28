using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebApplication1.Models;
using System.Data.Entity;

namespace WebApplication1.Controllers
{
    public class BooksController : Controller
    {
        public ActionResult Index() 
        {
            return View();
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Book book) 
        {
            Random r = new Random();
           // book.Id = r.Next();
            using (var bd = new BookContext())
            {
                bd.Books.Add(book);
                bd.SaveChanges();
            }
            return RedirectToAction("Index","Home"); ;
        }
        [HttpGet]
        public ActionResult Delete()
        {
            BookContext db = new BookContext();
            ViewBag.Books = db.Books;
            return View();
        }
        [HttpGet]
        public ActionResult DeleteBook(int id)
        {
            BookContext db = new BookContext();
            db.Books.RemoveRange(
                from Book in db.Books
                where Book.Id == id
                select Book
                );
            db.SaveChanges();
            return RedirectToAction("Delete", "Books"); ;
        }

    }
}