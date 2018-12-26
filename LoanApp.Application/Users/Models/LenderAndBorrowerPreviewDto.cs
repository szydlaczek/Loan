using System.Collections.Generic;

namespace LoanApp.Application.Users.Models
{
    public class LenderAndBorrowerPreviewDto
    {
        public LenderAndBorrowerPreviewDto()
        {
            Lenders = new HashSet<UserPreviewDto>();
            Borrowers = new HashSet<UserPreviewDto>();
        }

        public ICollection<UserPreviewDto> Lenders { get; set; }
        public ICollection<UserPreviewDto> Borrowers { get; set; }
    }
}