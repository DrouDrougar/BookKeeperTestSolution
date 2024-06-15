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
    internal class BookLoanRepository : IBookLoanRepository
    {
        private readonly ApplicationDbContext _context;
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
    }
}
