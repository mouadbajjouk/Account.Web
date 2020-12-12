using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounts.Web.Models
{
    public class AccountModel
    {
        public int Id { get; set; }
        [Required, Display(Name = "Account Number")]
        public string AccountNumber { get; set; }
        [Required, Display(Name = "Account Holder")]
        public string AccountHolder { get; set; }
        [Required, Display(Name = "Current Balance"), Column(TypeName = "decimal(28,2)")]
        public decimal CurrentBalance { get; set; }
        [Required, Display(Name = "Bank Name")]
        public string BankName { get; set; }
        [Required, Display(Name = "Opening Date"), DataType(DataType.Date)]
        public DateTime OpeningDate { get; set; }
        [Required, Display(Name = "Is Active")]
        public bool IsActive { get; set; }
    }
}
