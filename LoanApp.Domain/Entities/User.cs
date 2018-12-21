using System;
using System.Collections.Generic;
using System.Text;

namespace LoanApp.Domain.Entities
{
    public class User
    {
        public User()
        {
            SomeOneLoans = new HashSet<Loan>();
            MyLoans = new HashSet<Loan>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public bool IsBorrower { get; set; }
        public bool IsLender { get; set; }
        public ICollection<Loan> MyLoans { get; set; }
        public ICollection<Loan> SomeOneLoans { get; set; }
    }
}
