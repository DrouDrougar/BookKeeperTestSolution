using BookKeeper.Data.Models;
using BookKeeper.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeper.Test.Helper
{
    public class BookLoanHelper
    {
        public static BookLoan CreateBookLoan(IBookLoanRepository bookLoanRepository, User user, Book book)
        {
            return (CreateBookLoans(bookLoanRepository, user, new List<Book>() { book })).First();
        }

        public static List<BookLoan> CreateBookLoans(IBookLoanRepository bookLoanRepository, User user, List<Book> books)
        {
            List<BookLoan> result = new();

            foreach (var book in books)
            {
                BookLoan bookLoan = new BookLoan(user, book);
                bookLoanRepository.AddBookLoan(bookLoan);
                result.Add(bookLoan);
            }

            return result;
        }

    }
}
