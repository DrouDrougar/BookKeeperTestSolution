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
        public ApplicationDbContext _context;

        private DbContextOptions<ApplicationDbContext> _options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "BookKeeperTest")
            .Options;

        protected TestBase()
        {
            _context = new ApplicationDbContext(_options);
            _context.Database.EnsureCreated();

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
            if (books.Any())
            {
                _context.Books.AddRange(books);
            }
            else {  }

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
            if (users.Any())
            {
                _context.Users.AddRange(users);
            }
            else {  }
           
            //string earlierDate = "05-31-2024 23:59:59";
            //string laterDate = "06-19-2024 16:45:59";
            List<BookLoan> bookLoans = new List<BookLoan>()
        {
            new BookLoan() {Id = 1, StartDate = DateTime.UtcNow.AddDays(-4),EndDate = DateTime.UtcNow.AddDays(3), BookId = 1, UserId = 1},
            new BookLoan() {Id = 2, StartDate = DateTime.UtcNow,EndDate = DateTime.UtcNow.AddDays(7), BookId = 2, UserId = 2},
            new BookLoan() {Id = 3,  StartDate = DateTime.UtcNow,EndDate = DateTime.UtcNow.AddDays(7),BookId = 3, UserId = 3},
            new BookLoan() {Id = 4,  StartDate = DateTime.UtcNow.AddDays(-15),EndDate = DateTime.UtcNow.AddDays(-8),BookId = 4, UserId = 4},
            new BookLoan() {Id = 5,  StartDate = DateTime.UtcNow,EndDate = DateTime.UtcNow.AddDays(7), BookId = 5, UserId = 5}
          
        };
            if (bookLoans.Any())
            {
                _context.BookLoans.AddRange(bookLoans);
            }
            else { }
            

            _context.SaveChanges();
        }

        public void CreateNewBookLoan(DateTime dateTime, DateTime endDate, User user, Book book)
        {
            Book bookStatusChange;

            BookLoan bookLoan = new BookLoan(dateTime, endDate, user, book);
            bookStatusChange =  _context.Books.Find(book.BookId);
            bookStatusChange.LoanedOut = true;
            _context.Books.Update(bookStatusChange);
            _context.BookLoans.Add(bookLoan);
            _context.SaveChanges();
        }
        public void RemoveBookLoan(BookLoan bookLoanId)
        {
            if (bookLoanId.Id != null)
            {
                BookLoan bookLoan = _context.BookLoans.Where(l => l.Id == bookLoanId.Id).FirstOrDefault();
                _context.Remove(bookLoan);
                _context.SaveChanges();
            }
            else { Console.WriteLine("error No bookLoan with that Id exists"); }
        }

        public void FindBooksThatAreLate()
        {
            List<BookLoan> allBookLoans = _context.BookLoans.ToList();
            List<BookLoan> lateBookLoans = new List<BookLoan>(allBookLoans);
            lateBookLoans = (List<BookLoan>)_context.BookLoans.Where(bl => bl.EndDate <= DateTime.UtcNow);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
        }
    }

}


// Arrange

// Act

// Assert