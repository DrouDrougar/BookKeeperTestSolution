using BookKeeper.Data.Data;
using BookKeeper.Data.Models;

namespace BookKeeper.Data.Repositories
{
    public class BookRepository : IBookRepository
    {

        private readonly ApplicationDbContext _context;

        public bool BookLoanedOut(string title)
        {
            var theBookToCheck = _context.Books.SingleOrDefault(x => x.Title == title);
            if (theBookToCheck != null)
            {
                if (theBookToCheck.LoanedOut == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else { return false; };
            
        }

        public Book GetBookById(int id)
        {
            return _context.Books.SingleOrDefault(x => x.BookId == id);
        }

        public Book GetBookByTitle(string title)
        {
            return _context.Books.SingleOrDefault(x => x.Title == title);
        }

        public IEnumerable<List<Book>> GetBooks()
        {
            yield return _context.Books.ToList();
        }

        public List<Book> GetBooksByAuthor(string author)
        {
            return _context.Books.Where(x => x.Author == author).ToList();
        }
    }
}
