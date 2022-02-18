using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BudgetAmazon.Models;
using BudgetAmazon.ViewModel;

namespace BudgetAmazon.Controllers
{
    public class ShoppingController : Controller
    {
        private BudgetAmazonEntities objBudgetAmazonEntities;
        // GET: Shopping
        public ShoppingController()
        {
            objBudgetAmazonEntities = new BudgetAmazonEntities();
        }
        public ActionResult Index()
        {
            IEnumerable<ShoppingViewModel> listOfShoppingViewModels = (from objItem in objBudgetAmazonEntities.Items
                                                                       join  
                                                                       objCate in objBudgetAmazonEntities.Categories
                                                                       on objItem.CategoryId equals objCate.CategoryId
                                                                       select new ShoppingViewModel()
                                                                       {
                                                                           ImagePath = objItem.ImagePath,
                                                                           ItemName =  objItem.ItemName,
                                                                           Description = objItem.Description,
                                                                           ItemPrice = objItem.ItemPrice,
                                                                           ItemId = objItem.ItemId,
                                                                           Category = objCate.CategoryName,
                                                                           ItemCode = objItem.ItemCode
                                                                       }
                                                                       ).ToList();
            return View(listOfShoppingViewModels);
        }
    }
}