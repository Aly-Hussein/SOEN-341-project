using BudgetAmazon;
using BudgetAmazon.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace BudgetAmazon.Tests.Controllers
{
    [TestClass]
    public class ShoppingControllerTest
    {
        [TestMethod]
        public void Index_OnOpen_IsNotNull()
        {
            ItemController itemController = new ItemController();

            var result = itemController.Index() as ActionResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Index_ExecutesProperly_StatusCodeOk()
        {
            var shoppingController = new ShoppingController();

            var result = shoppingController.HttpContext.Response;

            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void ShoppingCart_OnOpen_IsNotNull()
        {
            var cartController = new ShoppingController();

            var result = cartController.ShoppingCart() as ActionResult;

            Assert.IsNotNull(result);
        }

    }
}
