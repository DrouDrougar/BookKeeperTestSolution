using BookKeeper.Data.Data;
using BookKeeper.Data.Models;
using BookKeeper.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookKeeper.Test
{
    public class BookTests : IDisposable
    {

        private static DbContextOptions<ApplicationDbContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "BookKeeperTest")
            .Options;

        ApplicationDbContext dbContext;
        IBookRepository _bookRepository;

        public BookTests()
        {
            dbContext = new ApplicationDbContext(dbContextOptions);
            dbContext.Database.EnsureCreated();

            SeedDatabase();
        }

        private void SeedDatabase()
        {
            List<Book> books = new List<Book>()
            {
                new Book() {BookId = 1, Author = "Johan"},
                new Book() {BookId = 2, Author = ""},
                new Book() {BookId = 3, Author = ""},
                new Book() {BookId = 4, Author = ""},
                new Book() {BookId = 5, Author = ""},
                new Book() {BookId = 6, Author = ""}
                };

        }

        [Fact]
        public void AreThereBookInTheDatabase_Test()
        {
            // Arrange

            // Act

            // Assert
        }
        [Fact]
        public void SearchForTitleInDatabase_Test()
        {
            // Arrange

            // Act

            // Assert
        }

        [Fact]
        public void SearchForAuthorBooksInDatabase_Test()
        {
            // Arrange

            // Act

            // Assert
        }
        [Fact]
        public void SearchForLoanedOutBooksInDatabase_Test()
        {
            // Arrange

            // Act

            // Assert
        }

        public void Dispose()
        {
            dbContext.Database.EnsureDeleted();
        }
    }
}
