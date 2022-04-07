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
    public class AccountControllerTest 
    {
        [TestMethod]
        public void Register_OnOpen_IsNotNull()
        {
            AccountController accountController = new AccountController();

            var result = accountController.Register() as ViewResult;
        
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ForgotPassword_OnOpen_IsNotNull()
        {
            AccountController accountController = new AccountController();

            var result = accountController.ForgotPassword() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ForgotPasswordConfirmation_OnOpen_IsNotNull()
        {
            AccountController accountController = new AccountController();

            var result = accountController.ForgotPasswordConfirmation() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ResetPasswordConfirmation_OnOpen_IsNotNull()
        {
            AccountController accountController = new AccountController();

            var result = accountController.ResetPasswordConfirmation() as ViewResult;

            Assert.IsNotNull(result);
        }

    }
}
