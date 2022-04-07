using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetAmazon.Models
{
    public class ContactModel
    {
        [Required(ErrorMessage = "   Field Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "   Field Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "   Field Required")]
        [EmailAddress(ErrorMessage = "   Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "   Field Required")]
        public string Comments { get; set; }
    }

}