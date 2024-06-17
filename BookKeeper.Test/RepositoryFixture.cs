using BookKeeper.Data.Data;
using BookKeeper.Data.Models;
using BookKeeper.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeper.Test
{
    public class RepositoryFixture : IDisposable
    {
        ApplicationDbContext dbContext;
        public IBookLoanRepository BookLoanRepository { get; private set; }
        public IBookRepository BookRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }

        public RepositoryFixture() 
        {
            var dbContext = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestDb").Options);

            BookLoanRepository = new Mock<IBookLoanRepository>().Object;
            BookRepository = new Mock<IBookRepository>().Object;
            UserRepository = new Mock<IUserRepository>().Object;

            SeedDatabase(dbContext);
        }
        public void SeedDatabase(ApplicationDbContext dbContext)
        {
            List<Book> books = new List<Book>()
            {
                new Book() {BookId = 1, Author = "Johan", Language = "English", Title = "Bannanas", LoanedOut = true},
                new Book() {BookId = 2, Author = "Anders", Language = "Spanish", Title = "Yo Soy La Bannanas", LoanedOut = false},
                new Book() {BookId = 3, Author = "Sven", Language = "French", Title = "Qui Le Bannanas", LoanedOut = false},
                new Book() {BookId = 4, Author = "Sven", Language = "Swedish", Title = "Bannanerna", LoanedOut = false},
                new Book() {BookId = 5, Author = "Jurgen", Language = "German", Title = "Daz U Bannanas", LoanedOut = false},
                new Book() {BookId = 6, Author = "Hendrik", Language = "America", Title = "Deep Fried Bannans", LoanedOut = false}
            };
            dbContext.Books.AddRange(books);

            List<User> users = new List<User>()
            {
                new User() {Id = 1, Email = "Johan@hotmail.com", FirstName = "Johan", LastName = "Johansson", HasBookLoan = false},
                new User() {Id = 2, Email = "Anders@hotmail.com", FirstName = "Anders", LastName = "Andersson", HasBookLoan = false},
                new User() {Id = 3, Email = "Sven@hotmail.com", FirstName = "Sven", LastName = "svensson", HasBookLoan = false},
                new User() {Id = 4, Email = "Jurgen@hotmail.com", FirstName = "Jurgen", LastName = "Jurgensson", HasBookLoan = false},
                new User() {Id = 5, Email = "Hendrik@hotmail.com", FirstName = "Hendrik", LastName = "Hendriksson", HasBookLoan = false},
                new User() {Id = 6, Email = "Lånare1@hotmail.com", FirstName = "Lånare1", LastName = "Lånares1son", HasBookLoan = false},
                new User() {Id = 7, Email = "Lånare2@hotmail.com", FirstName = "Lånare2", LastName = "Lånares2son", HasBookLoan = false}
            };
            dbContext.Users.AddRange(users);


            List<BookLoan> bookLoans = new List<BookLoan>()
            {
                new BookLoan() {Id = 1, BookId = 1, UserId = 1},
                new BookLoan() {Id = 2, BookId = 2, UserId = 2},
                new BookLoan() {Id = 3, BookId = 3, UserId = 3},
                new BookLoan() {Id = 4, BookId = 4, UserId = 4},
                new BookLoan() {Id = 5, BookId = 5, UserId = 5}
                //new BookLoan() {Id = 6, StartTime = DateTime.UtcNow, EndTime= DateTime.UtcNow.AddDays(7), BookId = 6, UserId = 6}
            };
            dbContext.BookLoans.AddRange(bookLoans);
            dbContext.SaveChanges();
        }
        public void Dispose()
        {
            dbContext.Database.EnsureDeleted();
        }
    }
}
