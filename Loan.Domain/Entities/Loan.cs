using System;
using System.Collections.Generic;
using System.Text;

namespace Loan.Domain.Entities
{
    public class Loan
    {
        public int BorrowerId { get; set; }
        public User Borrower { get; set; }




    }
}
