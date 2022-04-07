using BudgetAmazon;
using BudgetAmazon.Controllers;
using BudgetAmazon.Models;
using BudgetAmazon.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace BudgetAmazon.Tests.Controllers
{
    [TestClass]
    public class ItemControllerTest
    {

        [TestMethod]
        public void Index_ExecutesProperly_StatusCodeOk()
        {
            var itemController = new ItemController();
            ItemViewModel objItem = new ItemViewModel();

            objItem.ItemId = Guid.NewGuid();
            objItem.CategoryId = 1;
            objItem.ItemCode = "Test";
            objItem.ItemName = "TestName";
            objItem.Description = "Test";
            objItem.ItemPrice = 10;
            objItem.ImagePath = null;
            objItem.CategorySelectListItem = null;
            var result = itemController.Index(objItem);
            var data = result.Data.ToString();

            Assert.AreEqual(Regex.Replace("{Success = true, Message = Item is added Successfully.}".ToLower(), @"\s+", ""), Regex.Replace(data.ToLower(), @"\s+", ""));
        }


    }
}
