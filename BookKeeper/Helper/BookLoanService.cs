using BookKeeper.Data.Data;
using BookKeeper.Data.Models;
using BookKeeper.Data.Repositories;

namespace BookKeeper.Helper
{
    public class BookLoanService : BookLoanRepository
    {
        public BookLoanService(ApplicationDbContext context) : base(context)
        {
            
        }

        public void GetAllBookLoans(Book book, User user)
        {
            var startDate = DateTime.UtcNow;
            BookLoan bookLoan;
            //= new BookLoan(startDate, user, book);
            

        }
        public void CreateBookLoan()
        {

        }

        public void ReturnBookLoan()
        {

        }
    }
}
