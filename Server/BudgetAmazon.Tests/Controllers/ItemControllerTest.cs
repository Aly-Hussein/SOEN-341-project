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
    public class ItemControllerTest
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
            var itemController = new ItemController();

            var result = itemController.HttpContext.Response;

            Assert.AreEqual(200, result.StatusCode);
        }


    }
}
