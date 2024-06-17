using BookKeeper.Controllers;
using BookKeeper.Data.Data;
using BookKeeper.Data.Models;
using BookKeeper.Data.Repositories;
using BookKeeper.Test.Helper;
using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Common;
using FluentAssertions.Equivalency;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using NSubstitute;
using NSubstitute.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BookKeeper.Test
{
    public class BookLoanTest : TestBase
    {
        IBookRepository bookRepository;
        IBookLoanRepository bookLoanRepository;

        public BookLoanTest() 
        {
            bookRepository = new BookRepository(_dbContext);
            bookLoanRepository = new BookLoanRepository(_dbContext);
        }
        [Fact]
        public void AreThereAnyBookLoans_Test()
        {
            //Arrange
            BookLoan bookLoans;
            Book books = _dbContext.Books.Any();
            User users;

            var dateTime = DateTime.UtcNow; 
             bookLoans = _bookLoanRepositoryMock.AddBookLoan(dateTime, users.Id, books.BookId);

            _bookLoanRepositoryMock
                .IsBookBorrowed(1, 1)
                .Returns(true);
            //Act
            var result = _bookLoanRepositoryMock.GetLoanByTitle("title");

            //Assert
            Assert.Equal("title", result.Book.Title);
            
        }

        [Fact]
        public void CanWeCreateANewBookLoan_Test_ShouldReturnNewBookLoan()
        {
            //Arrange        
            var user = new User("Email@hotmail.com", "Johan", "Efternamn");
            var book = (bookRepository.GetBooks()).First();
            var dateTime = DateTime.Now;


            //Act

            BookLoan bookLoan = BookLoanHelper.CreateBookLoan(_bookLoanRepositoryMock ,dateTime, user, book);

            
            //bookedLoan = _bookLoanRepository.BookLoanAdd(bookLoan);
            //var bookLoanResults = BookLoans.Where(b => b.Book.Title == "Deep Fried Bannans").FirstOrDefault();

            //Assert
            var bookLoanUserResult = _bookLoanRepositoryMock.GetBooksByUser(user.FirstName);

            Assert.NotNull(bookLoanUserResult);
            Assert.Equal(bookLoan.User.FirstName, bookLoanUserResult.User.FirstName);
            Assert.Equal(bookLoan.StartDate, bookLoanUserResult.StartDate);



        }

        //public void Dispose()
        //{
        //    dbContext.Database.EnsureDeleted();
        //}
    }
}
