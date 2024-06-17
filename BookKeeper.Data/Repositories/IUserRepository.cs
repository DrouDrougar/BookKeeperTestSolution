using BookKeeper.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeper.Data.Repositories
{
    public interface IUserRepository
    {
        public User CreateUser(string email, string firstName, string lastName);
        
        public List<User> GetUsers();

        public User GetById(int id);    

        public List<User> GetUsersWithLoans(bool loanTrue);
    }
}
