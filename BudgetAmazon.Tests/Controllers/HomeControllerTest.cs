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
    public class HomeControllerTest
    {

        [TestMethod]
        public void Index()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About_OnOpen_IsNotNull()
        {
            var controller = new HomeController();

            var result = controller.About() as ViewResult;

            Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void Contact_OnOpen_IsNotNull()
        {
            var controller = new HomeController();

            var result = controller.Contact() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Service_OnOpen_IsNotNull()
        {
            var controller = new HomeController();

            var result = controller.Service() as ViewResult;

            Assert.IsNotNull(result);
        }
    }
}
