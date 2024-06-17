using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeper.Data.Models
{
    public class BookLoan
    {
        public BookLoan()
        {

        }

        public BookLoan(DateTime datetime, User user, Book book)
        {
            StartDate = datetime;
            User = user;
            Book = book;
        }

        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
