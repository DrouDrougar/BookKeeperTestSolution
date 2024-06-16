using BookKeeper.Data.Models;
using BookKeeper.Data.Repositories;
using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeper.Test
{
    public class ControllersTest
    {
        private readonly IBookRepository bookRepository;
        private readonly IBookLoanRepository bookLoanRepository;
        private readonly IUserRepository userRepository;

        public ControllersTest()
        {
            bookRepository = A.Fake<IBookRepository>();
            bookLoanRepository = A.Fake<IBookLoanRepository>();
            userRepository = A.Fake<IUserRepository>();
        }

        [Fact]
        public void TestIfBookControllerCanCreateNewBooks_Create_ExpectedToReturnTrue()
        {
            //Arrange

            //Act

            //Assert
        }
        [Fact]
        public void BookController_Index_ExpectedToReturnTrue()
        {
            //Arrange
            var books = A.Fake<IEnumerable<Book>>();
            //A.CallTo(() => bookRepository.GetBooks()).Returns(books);
            //Act


            //Assert
        }
    }
}
