using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BudgetAmazon.Models;
using BudgetAmazon.ViewModel;

namespace BudgetAmazon.Controllers
{
    public class ItemController : Controller
    {
        private BudgetAmazonEntities objBudgetAmazonEntities;
        public ItemController()
        {
            objBudgetAmazonEntities = new BudgetAmazonEntities();

        }
        // GET: Item
        public ActionResult Index()
        {
            ItemViewModel objItemViewModel = new ItemViewModel();
            objItemViewModel.CategorySelectListItem = (from objCat in objBudgetAmazonEntities.Categories select new SelectListItem()
                                                        {
                                                        Text = objCat.CategoryName,
                                                        Value = objCat.CategoryId.ToString(),
                                                        Selected = true
                                                        });
            return View(objItemViewModel);
        }

        public JsonResult Index()
        {
            return Json(data:"HHHH", JsonRequestBehavior.AllowGet);
        }
    }
}