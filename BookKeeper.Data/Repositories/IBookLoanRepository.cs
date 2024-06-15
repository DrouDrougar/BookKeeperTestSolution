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
        public List<BookLoan> BookLoan();
        public BookLoan GetLoanById(int id);
        public BookLoan GetLoanByTitle(string title);
        public BookLoan GetBooksByUser(string user);
    }
}
