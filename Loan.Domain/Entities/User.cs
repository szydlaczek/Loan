using System;
using System.Collections.Generic;
using System.Text;


namespace Loan.Domain.Entities
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public bool IsBorrower { get; set; }
        public bool IsLender { get; set; }
    }
}
