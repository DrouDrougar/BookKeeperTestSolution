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
        private readonly DateTime returnDate;

        public BookLoan()
        {

        }

        public BookLoan(DateTime datetime, DateTime endDate ,User user, Book book)
        {
            StartDate = datetime;
            EndDate = endDate;
            User = user;
            Book = book;
        }

        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
