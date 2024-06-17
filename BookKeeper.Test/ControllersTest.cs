using BookKeeper.Controllers;
using BookKeeper.Data.Data;
using BookKeeper.Data.Models;
using BookKeeper.Data.Repositories;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
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
        private readonly ApplicationDbContext _context;

        public ControllersTest()
        {
            bookRepository = A.Fake<IBookRepository>();
            bookLoanRepository = A.Fake<IBookLoanRepository>();
            userRepository = A.Fake<IUserRepository>();
            _context = A.Fake<ApplicationDbContext>();
        }
    }
}
