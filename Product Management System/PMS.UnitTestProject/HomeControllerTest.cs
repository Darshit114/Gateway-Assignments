using Microsoft.VisualStudio.TestTools.UnitTesting;
using Product_Management_System.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace PMS.UnitTestProject
{
    /// <summary>
    /// Summary description for HomeControllerTest
    /// </summary>
    [TestClass]
    public class HomeControllerTest
    {
        public HomeControllerTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController homeController = new HomeController();

            // Act
            var home = homeController.Index() as ViewResult;
            var login = homeController.Login() as ViewResult;
            var product = homeController.Product() as ViewResult;

            // Assert
            Assert.IsNull(home);
            Assert.IsNull(login);
            Assert.IsNull(product);
        }

        [TestMethod]
        public void Products()
        {

        }
    }
}
