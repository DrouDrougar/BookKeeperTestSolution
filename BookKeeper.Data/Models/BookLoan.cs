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

        public BookLoan(User user, Book book)
        {

            User = user;
            Book = book;
        }

        public int Id { get; set; }

        public Book Book { get; set; }
        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }
        public User User { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
    }
}
