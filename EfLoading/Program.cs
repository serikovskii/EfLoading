using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfLoading
{
    class Program
    {
        static void Main(string[] args)
        {
            //var author = new Author
            //{
            //    Name = "Pushkin"
            //};
            //var book = new Book
            //{
            //    Name = "skazki",
            //    Price = 1000,
            //    AuthorId = author.Id
            //};
            //using (var context = new LibraryContext())
            //{
            //    context.Authors.Add(author);
            //    context.Books.Add(book);
            //    context.SaveChanges();
            //}

            using (var context = new LibraryContext())
            {
                var book = context.Books.SingleOrDefault();
                context.Entry(book).Reference("Author").Load();
                var author = book.Author;

                // LazyLoading - ленивая загрузка virtual в своства, работает внутри using
                // EagerLoading - жадная загрузка Book.Include("Author")
                // ExplicitLoading - явная загрузка context.Entry(book).Reference("Author")/Collection("Authors").Load();  работает внутри using
            }
        }
    }
}
