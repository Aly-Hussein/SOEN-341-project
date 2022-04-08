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
    public class ManageControllerTest
    {

        [TestMethod]
        public void SetPassword_OnOpen_IsNotNull()
        {
            var controller = new ManageController();

            var result = controller.SetPassword() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]

        public void ChangePassword_OnOpen_IsNotNull()
        {
            var controller = new ManageController();

            var result = controller.ChangePassword() as ViewResult;

            Assert.IsNotNull(result);
        }

    }
}
