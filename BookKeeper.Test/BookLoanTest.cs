﻿using BookKeeper.Data.Data;
using BookKeeper.Data.Models;
using BookKeeper.Data.Repositories;
using BookKeeper.Test.Helper;
using FakeItEasy;
using FluentAssertions.Common;
using FluentAssertions.Equivalency;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeper.Test
{
    public class BookLoanTest : IDisposable
    {

        private static DbContextOptions<ApplicationDbContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "BookKeeperTest")
            .Options;

        ApplicationDbContext dbContext;
        private readonly IBookRepository _bookRepository;
        private readonly IBookLoanRepository _bookLoanRepository;
        private readonly IUserRepository _userRepository;



        public BookLoanTest(IBookLoanRepository bookLoanRepository, IBookRepository bookRepository, IUserRepository userRepository) : base()
        {
            dbContext = new ApplicationDbContext(dbContextOptions);
            _bookLoanRepository = new BookLoanRepository(dbContext);
            _bookRepository = new BookRepository(dbContext);
            _userRepository = new UserRepository(dbContext);
            dbContext.Database.EnsureCreated();

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

        [Fact]
        public void AreThereAnyBookLoans_Test()
        {
            //Arrange
            BookLoan bookLoan = new BookLoan();

            //Act
            var bookLoanCounter = dbContext.BookLoans.Any();

            //Assert
            Assert.True(bookLoanCounter);


        }

        [Fact]
        public void CanWeCreateANewBookLoan_Test_ShouldReturnNewBookLoan()
        {
            //Arrange

            BookLoan bookLoan = new BookLoan();
            BookLoan bookedLoan = new BookLoan();
            BookLoan theFinalBook = new BookLoan();


            //Act
            var user = _userRepository.GetById(6);
            var book = _bookRepository.GetBookById(6);
            bookLoan = BookLoanHelper.CreateBookLoan(_bookLoanRepository ,user, book);

            //bookedLoan = _bookLoanRepository.BookLoanAdd(bookLoan);
            var bookLoanResults = dbContext.BookLoans.Where(b => b.Book.Title == "Deep Fried Bannans").FirstOrDefault();
          
            //Assert
            Assert.Equal("Deep Fried Bannans", bookLoanResults.Book.Title);


        }

        public void Dispose()
        {
            dbContext.Database.EnsureDeleted();
        }
    }
}
