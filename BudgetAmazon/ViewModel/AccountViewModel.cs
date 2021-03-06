using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BudgetAmazon.ViewModel
{
    public class AccountViewModel
    {
        public System.Guid CustomerId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public IEnumerable<SelectListItem> AccountSelectListItem { get; set; }
    }
}