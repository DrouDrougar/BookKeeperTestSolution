using BookKeeper.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeper.Data.Repositories
{
    public interface IBookLoanRepository
    {
        public BookLoan AddBookLoan(BookLoan bookLoan);
        public BookLoan AddBookLoan(DateTime startDate, int userId, int bookId);
        public List<BookLoan> GetBookLoans();
        public BookLoan GetLoanById(int id);
        public BookLoan GetLoanByTitle(string title);
        public BookLoan GetBooksByUser(string user);
        public bool IsBookBorrowed(int userId, int bookId);
    }
}
