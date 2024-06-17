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
    public class BookLoanRepository : IBookLoanRepository
    {
        private readonly ApplicationDbContext _context;

        public BookLoanRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public BookLoan AddBookLoan(BookLoan bookLoan)
        {
            _context.BookLoans.Add(bookLoan);
            _context.SaveChanges();
            return bookLoan;
        }
        public BookLoan AddBookLoan(int userId, int bookId)
        {

            var user = _context.Users.Find(userId);
            var book = _context.Books.Find(bookId);
            var newBookLoan = new BookLoan(user: user, book: book);

            return AddBookLoan(newBookLoan);
        }

        public List<BookLoan> BookLoan()
        {
            throw new NotImplementedException();
        }


        public BookLoan GetBooksByUser(string user)
        {
            return _context.BookLoans.SingleOrDefault(x => x.User.FirstName == user);
        }

        public BookLoan GetLoanById(int id)
        {
            return _context.BookLoans.SingleOrDefault(x => x.Id == id);
        }

        public BookLoan GetLoanByTitle(string title)
        {
            return _context.BookLoans.SingleOrDefault(x => x.Book.Title == title);
        }

        public bool IsBookBorrowed(int userId, int bookId)
        {
            throw new NotImplementedException();
        }
    }
}
