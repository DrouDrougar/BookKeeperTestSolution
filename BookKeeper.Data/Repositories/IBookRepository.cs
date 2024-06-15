using BookKeeper.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeper.Data.Repositories
{
    public interface IBookRepository
    {
        public List<Book> GetBooksAsync();
        public Book GetBookById(int id);
        public Book GetBookByTitle(string title);
        public List<Book> GetBooksByAuthor(string author);
        public bool BookLoanedOut(string title);

    }
}
