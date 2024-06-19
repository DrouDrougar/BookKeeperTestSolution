using BookKeeper.Controllers;
using BookKeeper.Data.Data;
using BookKeeper.Data.Models;
using BookKeeper.Data.Repositories;
using BookKeeper.Test.Helper;
using FluentAssertions;
using NuGet.ContentModel;

namespace BookKeeper.Test
{
    public class BookLoanTest : TestBase
    {

        [Fact]
        public void CheckIfThereAreBookLoansInTheSystem_Test_ShouldReturnPossitive()
        {
            // Arrange
            List<BookLoan> bookLoan;

            // Act
            bookLoan = _context.BookLoans.ToList();

            // Assert
            Assert.Equal(5, bookLoan.Count);
        }

        [Fact]
        public void AddANewBookOrderToTheDataBase()
        {
            //Arrange
            BookLoan result;
            User user;
            Book book;
            DateTime dateTime = DateTime.Now;
            DateTime endTime = DateTime.Now.AddDays(7);

            //Act
            
            user = _context.Users.Find(6);
            //bookid of 6 got title of "Deep Fried Bannans"
            book = _context.Books.Find(6);
            CreateNewBookLoan(dateTime, endTime, user, book);

            result = _context.BookLoans.Where(b => b.Book.BookId == book.BookId).FirstOrDefault();

            //Assert
            Assert.Equal("Deep Fried Bannans", result.Book.Title);
            Assert.True(book.LoanedOut = true);
             
        }

        [Fact]
        public void RemoveCurrentBookLoan_Test_ShouldReturnFalse()
        {
            // Arrange
            BookLoan bookLoan;
            BookLoan result;

            // Act
            bookLoan = _context.BookLoans.Find(5);
            RemoveBookLoan(bookLoan);
            result = _context.BookLoans.Find(5);

            // Assert
            Assert.False(result != null);
        }

        [Fact]
        public void CheckForExpiredBookLoans_Test_ShouldReturnAPossitiveLateLoan()
        {
            //Arrange
            List<BookLoan> bookLoans = _context.BookLoans.ToList();
            bool result = false;
            DateTime dateTime = DateTime.Now;

            //Act
            bookLoans = (List<BookLoan>)_context.BookLoans.Where(b => b.EndDate <= dateTime).ToList();
            if (bookLoans != null)
            { result = true; }

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void ProlongACurrentBookLoan_Test_ShouldReturnAPossitiveAndANegativeIfTheLoanHadAlreadyExpired()
        {
            //Arrange
            BookLoan bookLoan;
            BookLoan lateBookLoan;
            DateTime currentDateTime = DateTime.Now;
            bool isBookAlreadyLate = false;

            //Act
            bookLoan = _context.BookLoans.Find(1);

            lateBookLoan = _context.BookLoans.Find(4);

            if (bookLoan.EndDate <= currentDateTime)
            {
                isBookAlreadyLate = false;
                bookLoan.EndDate = currentDateTime.AddDays(7);
            }
            if (lateBookLoan.EndDate <= currentDateTime)
            {
                isBookAlreadyLate = true;
                bookLoan.EndDate = currentDateTime.AddDays(7);
            }

            //Assert
            Assert.Equal(currentDateTime.AddDays(7), bookLoan.EndDate);
            Assert.True(isBookAlreadyLate);
        }
        public void Dispose()
        {
            _context.Database.EnsureDeleted();
        }
    

    }
}



//private readonly ApplicationDbContext _context;

//private DbContextOptions<ApplicationDbContext> _options = new DbContextOptionsBuilder<ApplicationDbContext>()
//    .UseInMemoryDatabase(databaseName: "BookKeeperTest")
//    .Options;

//public BookLoanTest() : base()
//{
//    //_context = new ApplicationDbContext(_options);
//    //_context.Database.EnsureCreated();

//    //SeedDatabase();
//}
//public void SeedDatabase()
//{
//    List<Book> books = new List<Book>()
//{
//    new Book() {BookId = 1, Author = "Johan", Language = "English", Title = "Bannanas", LoanedOut = true},
//    new Book() {BookId = 2, Author = "Anders", Language = "Spanish", Title = "Yo Soy La Bannanas", LoanedOut = false},
//    new Book() {BookId = 3, Author = "Sven", Language = "French", Title = "Qui Le Bannanas", LoanedOut = false},
//    new Book() {BookId = 4, Author = "Sven", Language = "Swedish", Title = "Bannanerna", LoanedOut = false},
//    new Book() {BookId = 5, Author = "Jurgen", Language = "German", Title = "Daz U Bannanas", LoanedOut = false},
//    new Book() {BookId = 6, Author = "Hendrik", Language = "America", Title = "Deep Fried Bannans", LoanedOut = false}
//};
//    _context.Books.AddRange(books);

//    List<User> users = new List<User>()
//{
//    new User() {Id = 1, Email = "Johan@hotmail.com", FirstName = "Johan", LastName = "Johansson", HasBookLoan = false},
//    new User() {Id = 2, Email = "Anders@hotmail.com", FirstName = "Anders", LastName = "Andersson", HasBookLoan = false},
//    new User() {Id = 3, Email = "Sven@hotmail.com", FirstName = "Sven", LastName = "svensson", HasBookLoan = false},
//    new User() {Id = 4, Email = "Jurgen@hotmail.com", FirstName = "Jurgen", LastName = "Jurgensson", HasBookLoan = false},
//    new User() {Id = 5, Email = "Hendrik@hotmail.com", FirstName = "Hendrik", LastName = "Hendriksson", HasBookLoan = false},
//    new User() {Id = 6, Email = "Lånare1@hotmail.com", FirstName = "Lånare1", LastName = "Lånares1son", HasBookLoan = false},
//    new User() {Id = 7, Email = "Lånare2@hotmail.com", FirstName = "Lånare2", LastName = "Lånares2son", HasBookLoan = false}
//};
//    _context.Users.AddRange(users);


//    List<BookLoan> bookLoans = new List<BookLoan>()
//{
//    new BookLoan() {Id = 1, StartDate = DateTime.UtcNow, BookId = 1, UserId = 1},
//    new BookLoan() {Id = 2, StartDate = DateTime.UtcNow, BookId = 2, UserId = 2},
//    new BookLoan() {Id = 3,  StartDate = DateTime.UtcNow,BookId = 3, UserId = 3},
//    new BookLoan() {Id = 4,  StartDate = DateTime.UtcNow,BookId = 4, UserId = 4},
//    new BookLoan() {Id = 5,  StartDate = DateTime.UtcNow,BookId = 5, UserId = 5}
//    //new BookLoan() {Id = 6, StartTime = DateTime.UtcNow, EndTime= DateTime.UtcNow.AddDays(7), BookId = 6, UserId = 6}
//};
//    _context.BookLoans.AddRange(bookLoans);

//    _context.SaveChanges();
//}