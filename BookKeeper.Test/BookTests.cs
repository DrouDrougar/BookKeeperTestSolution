using BookKeeper.Data.Data;
using BookKeeper.Data.Models;
using BookKeeper.Data.Repositories;
using FakeItEasy;
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
        private readonly IBookRepository _bookRepository;

     

        public BookTests()
        {
            //dbContext = new ApplicationDbContext(dbContextOptions);
            dbContext.Database.EnsureCreated();

            _bookRepository = A.Fake<IBookRepository>();
            SeedDatabase();
        }

        public List<Book> SeedDatabase()
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
            return books;
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
            A.CallTo(() => _bookRepository.BookLoanedOut("Bannanas")).Returns(true);

            // Act

            // Assert
        }

        public void Dispose()
        {
            dbContext.Database.EnsureDeleted();
        }
    }
}
