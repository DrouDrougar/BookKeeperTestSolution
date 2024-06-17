using BookKeeper.Data.Data;
using BookKeeper.Data.Models;
using BookKeeper.Data.Repositories;
using BookKeeper.Test.Helper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookKeeper.Test
{
    public class BookTests : TestBase, IDisposable
    {

        [Fact]
        public void AreThereBookInTheDatabase_Test_ReturnTrue()
        {
            // Arrange
            //Book book;
     
            // Act
            var bookCounter = _context.Books.Any();

            // Assert
            Assert.True(bookCounter);
            bookCounter.Should().Be(true);

        }
        [Fact]
        public void SearchForTitleInDatabase_Test()
        {
            // Arrange
            Book book;

            // Act
            book = _context.Books.Where(a => a.Title == "Qui Le Bannanas").FirstOrDefault();

            // Assert
            Assert.Equal("Qui Le Bannanas", book.Title);
        }

        [Fact]
        public void SearchForAuthorBooksInDatabase_Test_ExpectedToReturnTrue()
        {
            // Arrange
            Book book;

            // Act
            book = _context.Books.Where(a => a.Author == "Johan").FirstOrDefault();

            // Assert
            Assert.Equal("Johan", book.Author);
        }

        [Fact]
        public void SearchForLoanedOutBooksInDatabase_Test()
        {

            // Arrange
            Book book;

            // Act
            book = _context.Books.Where(b => b.LoanedOut == true).FirstOrDefault();

            // Assert
            Assert.True(book.LoanedOut);
            
           
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
        }
    }
}
