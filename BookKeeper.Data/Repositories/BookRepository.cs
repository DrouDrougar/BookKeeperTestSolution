using BookKeeper.Data.Data;
using BookKeeper.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeper.Data.Repositories
{
    public class BookRepository : IBookRepository
    {

        private readonly ApplicationDbContext _context;
        public Book GetBookById(int id)
        {
            return _context.Books.SingleOrDefault(x => x.BookId == id);
        }

        public Book GetBookByTitle(string title)
        {
            return _context.Books.SingleOrDefault(x => x.Title == title);
        }

        public List<Book> GetBooksAsync()
        {
            return _context.Books.ToList();
        }

        public List<Book> GetBooksByAuthor(string author)
        {
            return _context.Books.Where(x => x.Author == author).ToList();
        }
    }
}
