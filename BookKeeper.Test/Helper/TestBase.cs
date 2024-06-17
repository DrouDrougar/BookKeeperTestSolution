using BookKeeper.Controllers;
using BookKeeper.Data.Data;
using BookKeeper.Data.Models;
using BookKeeper.Data.Repositories;
using BookKeeper.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Moq;
using BookKeeper.Data.Migrations;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Data.Entity;

namespace BookKeeper.Test.Helper
{
    public class TestBase
    {
        protected ApplicationDbContext _dbContext;

        protected User _DefaultSeedUserData = new User("Email@hotmail.com", "Johan", "Efternamn");

        private DbContextOptions<ApplicationDbContext> _options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("BookKeeperTestBase")
            .Options;

        protected readonly Mock<UserRepository> _userRepositoryMock;
        protected readonly Mock<BookRepository> _bookRepositoryMock;
        protected readonly Mock<BookLoanRepository> _bookLoanRepositoryMock;

        protected TestBase()
        {
            _dbContext = new ApplicationDbContext(_options);
            _dbContext.Database.EnsureCreated();

            SeedDatabase();
        }
        public void SeedDatabase()
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
            _dbContext.Books.AddRange(books);

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
            _dbContext.Users.AddRange(users);


            List<BookLoan> bookLoans = new List<BookLoan>()
        {
            new BookLoan() {Id = 1, StartDate = DateTime.UtcNow, BookId = 1, UserId = 1},
            new BookLoan() {Id = 2, StartDate = DateTime.UtcNow, BookId = 2, UserId = 2},
            new BookLoan() {Id = 3,  StartDate = DateTime.UtcNow,BookId = 3, UserId = 3},
            new BookLoan() {Id = 4,  StartDate = DateTime.UtcNow,BookId = 4, UserId = 4},
            new BookLoan() {Id = 5,  StartDate = DateTime.UtcNow,BookId = 5, UserId = 5}
            //new BookLoan() {Id = 6, StartTime = DateTime.UtcNow, EndTime= DateTime.UtcNow.AddDays(7), BookId = 6, UserId = 6}
        };
            _dbContext.BookLoans.AddRange(bookLoans);

            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
        }
    }

}
