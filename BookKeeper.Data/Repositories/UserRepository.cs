﻿using BookKeeper.Data.Data;
using BookKeeper.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeper.Data.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public User CreateUser(string email, string firstName, string lastName)
        {
            var user = new User(email, firstName, lastName);
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
        public User GetById(int id)
        {
            return _context.Users.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public List<User> GetUsersWithLoans(bool loanTrue)
        {
            return _context.Users.Where(x => x.HasBookLoan == loanTrue == true).ToList();
        }
    }
}
