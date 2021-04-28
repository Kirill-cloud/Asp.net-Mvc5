using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class BookDbInitializer : CreateDatabaseIfNotExists<BookContext>
    {
        protected override void Seed(BookContext db)
        {
            db.Books.Add(new Book { Name = "Война и мир",  Price = 220 });
            db.Books.Add(new Book { Name = "Отцы и дети",  Price = 180 });
            db.Books.Add(new Book { Name = "Чайка",  Price = 150 });

            base.Seed(db);
        }
    }
}