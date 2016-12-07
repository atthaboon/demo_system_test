using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_system_test
{
    [TestFixture]
    public class LoginTest
    {
        IWebDriver driver;

        [TestFixtureSetUp]
        public void OpenWebBrowser()
        {
            driver = new ChromeDriver();
            // driver.Navigate().GoToUrl("http://spe.sectorpensjon.net/PuST/Login");
            // driver.Navigate().Refresh();
        }

        [TestFixtureTearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }

        [SetUp]
        public void GoToHomePage()
        {
            driver.Navigate().GoToUrl("http://spe.sectorpensjon.net/PuST/Login");
            driver.Navigate().Refresh();
        }

        [TearDown]
        public void ClearWebSeession()
        {
            driver.Manage().Cookies.DeleteAllCookies();
        }

        [Test]
        public void Login_CorrectUsernameAndPassword_RedirectToProspectPage()
        {
            // Arrange

            // Act
            Login("admin", "admin@123");

            // Assert
            var logoutBtn = driver.FindElement(By.Id("login-btn"));
            Assert.NotNull(logoutBtn);
        }

        [Test]
        public void Login_IncorrectUsernameAndPassword_DisplayErrorMessage()
        {
            // Arrange

            // Act
            Login("admin", "admin@1234");

            // Assert
            var errorDialog = driver.FindElement(By.ClassName("validation-summary-errors"));
            Assert.AreEqual("Feil brukernavn eller passord.", errorDialog.Text);
        }

        private void Login(string username, string password)
        {
            var userNameTB = driver.FindElement(By.Id("UserName"));
            userNameTB.Clear();
            userNameTB.SendKeys(username);
            var passwordTB = driver.FindElement(By.Id("Password"));
            passwordTB.Clear();
            passwordTB.SendKeys(password);
            var submitBtn = driver.FindElement(By.Name("loginForm"));
            submitBtn.Click();
        }
        
    }
}
