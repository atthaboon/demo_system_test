using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace demo_system_test
{
    [TestFixture]
    public class TestForgetPwd
    {
        private IWebDriver driver;
        private const string FORGET_NOTIFY_MSG = "Er en aktiv bruker angitt, skal nå en lenke for å legge inn nytt passord ha blitt sendt til din epost. Kontakt Pensjon Pluss hvis du trenger bistand!";

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
         public void ResetPwd_withoutUsername_ShowWarningMessage()
         {

             var userNameTB = driver.FindElement(By.Id("UserName"));
             userNameTB.Clear();
             var passwordTB = driver.FindElement(By.Id("Password"));
             passwordTB.Clear();
             var resetpwd = driver.FindElement(By.Id("Reset Password"));
             resetpwd.Click();
             var warningMsgTxt = driver.FindElement(By.ClassName("field-validation-error"));
             Assert.AreEqual("Legg inn brukernavn", warningMsgTxt.Text);

         }

         [Test]
         public void ResetPwd_WithIncorrectUsername()
         {
             var userNameTB = driver.FindElement(By.Id("UserName"));
             //userNameTB.Clear();
             userNameTB.SendKeys("admin123");
             var resetpwd = driver.FindElement(By.Id("Reset Password"));
             resetpwd.Click();
             var successMsgTxt = driver.FindElement(By.ClassName("viewBag-success"));
             Assert.AreEqual(FORGET_NOTIFY_MSG, successMsgTxt.Text);
         }

        [Test]
        public void ResetPwd_WithInputSpecialCharinUsername()
        {
            var userNameTB = driver.FindElement(By.Id("UserName"));
            //userNameTB.Clear();
            userNameTB.SendKeys("!@#$%^&*()_+");
            var resetpwd = driver.FindElement(By.Id("Reset Password"));
            resetpwd.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            var successMsgTxt = driver.FindElement(By.ClassName("viewBag-success"));
            Assert.AreEqual(FORGET_NOTIFY_MSG, successMsgTxt.Text);
        }

        [Test]
         public void ResetPwd_WithcorrectUsername()
         {
             var userNameTB = driver.FindElement(By.Id("UserName"));
             //userNameTB.Clear();
             userNameTB.SendKeys("admin");
             var passwordTB = driver.FindElement(By.Id("Password"));
             passwordTB.Clear();
             var resetpwd = driver.FindElement(By.Id("Reset Password"));
             resetpwd.Click();
             driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
             var usernamecorrectSuccessMsgTxt = driver.FindElement(By.ClassName("viewBag-success"));
             Assert.AreEqual(FORGET_NOTIFY_MSG, usernamecorrectSuccessMsgTxt.Text);
         } 

    }

}