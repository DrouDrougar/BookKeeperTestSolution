using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeper.Data.Models
{
    public class User
    {
        public User() { }

        public User(string email, string firstName, string lastName) 
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? HasBookLoan { get; set; }

    }
}
