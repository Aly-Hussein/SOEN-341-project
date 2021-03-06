using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BudgetAmazon.Models;
using BudgetAmazon.ViewModel;

namespace BudgetAmazon.Controllers
{
    public class ItemController : Controller
    {
        private BudgetAmazonEntities3 objBudgetAmazonEntities;
        public ItemController()
        {
            objBudgetAmazonEntities = new BudgetAmazonEntities3();

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

        [HttpPost]
        public JsonResult Index(ItemViewModel objItemViewModel) 
        {
            string NewImage = "";
            if (objItemViewModel.ImagePath == null)
            {
                NewImage = "Image1.jpg";
            }
            else
            {
                NewImage = Guid.NewGuid() + Path.GetExtension(objItemViewModel.ImagePath.FileName);
                objItemViewModel.ImagePath.SaveAs(Server.MapPath("~/Images/" + NewImage));
            }
            
            Item objItem = new Item();
            objItem.ImagePath = "~/Images/" + NewImage;
            objItem.CategoryId = objItemViewModel.CategoryId;
            objItem.Description = objItemViewModel.Description;
            objItem.ItemCode = objItemViewModel.ItemCode;
            objItem.ItemId = Guid.NewGuid();
            objItem.ItemName = objItemViewModel.ItemName;
            objItem.ItemPrice = objItemViewModel.ItemPrice;

            if (NewImage != "Image1.jpg")
            {
                objBudgetAmazonEntities.Items.Add(objItem);
                objBudgetAmazonEntities.SaveChanges();
            }

            return Json(new {Success = true, Message = "Item is added Successfully."}, JsonRequestBehavior.AllowGet);
        }
    }
}