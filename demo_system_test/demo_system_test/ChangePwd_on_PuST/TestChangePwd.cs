using Bumblebee.Setup;
using Bumblebee.Setup.DriverEnvironments;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_system_test.ChangePwd_on_PuST
{
    [TestFixture]
    class TestChangePwd
    {
        IWebDriver driver;

        [TestFixtureSetUp]
        public void OpenWebBrowser()
        {
            driver = new ChromeDriver();
            // driver.Navigate().GoToUrl("http://spe.sectorpensjon.net/PuST/Password/ChangePassword");
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
            driver.Navigate().GoToUrl("http://spe.sectorpensjon.net/PuST/Password/ChangePassword");
            driver.Navigate().Refresh();
        }

        [TearDown]
        public void ClearWebSeession()
        {
            driver.Manage().Cookies.DeleteAllCookies();
        }

        //case1: change Pwd with didn't Ent anything.
        [Test]
        public void ChangePwd_WithNotEntAnything_DisplayErrorMsg()
        {
            // Arrange
            var ChangePasswordPage = Threaded<Session>
            .With<Chrome>()
            .NavigateTo<ChangePasswordPage>("http://spe.sectorpensjon.net/PuST/Password/ChangePassword");

            // Action
            var ChangePwdWithoutEntAnything = ChangePasswordPage.SaveChangePwdForm("", "", "", "");

            //Assert
            Assert.AreEqual("The Username field is required.", ChangePasswordPage.ErrorMsgWhenNotEntUsername);
            Assert.AreEqual("The Current password field is required.", ChangePasswordPage.CurrentPasswordErrorTextField);
            Assert.AreEqual("The New password field is required.", ChangePasswordPage.NewPasswordErrorTextField);
        }

        //case2: change Pwd with didn't Ent Confirm newPwd only.
        [Test]
        public void ChangePwd_WithNotEntConfirmNewPwdOnly_DisplayConfirmPwdErrorMsg()
        {
            // Arrange
            var ChangePasswordPage = Threaded<Session>
            .With<Chrome>()
            .NavigateTo<ChangePasswordPage>("http://spe.sectorpensjon.net/PuST/Password/ChangePassword");

            // Action
            var ChangePwdWhenNotEntConfirmNewPwd = ChangePasswordPage.SaveChangePwdForm("admin", "admin@123", "admin@1234", "");

            //Assert
            Assert.AreEqual("The new password and confirmation password do not match.", ChangePwdWhenNotEntConfirmNewPwd.ConfirmPasswordErrorTextField);
        }

        //case3: change Pwd with Invalid currentPwd.
        [Test]
        public void ChangePwd_WithInvalidCurrentPwd_DisplayCurrentPwdValidationErrorMsg()
        {
            // Arrange
            var ChangePasswordPage = Threaded<Session>
            .With<Chrome>()
            .NavigateTo<ChangePasswordPage>("http://spe.sectorpensjon.net/PuST/Password/ChangePassword");

            // Action
            var ChangePwdWhenInvCurrentPwd = ChangePasswordPage.SaveChangePwdForm("admin", "admin@111", "admin@1234", "admin@1234");

            //Assert
           Assert.AreEqual("Current password is not valid", ChangePwdWhenInvCurrentPwd.CurrentPasswordIsInvalidTextField);
        }

        //case4: change Pwd with Ent ConfirmPwd is NOT match with NewPwd.
        [Test]
        public void ChangePwd_WithConfirmPwdIsNotMatchWithNewPwd()
        {
            //Arrange
            var ChangePasswordPage = Threaded<Session> 
            .With<Chrome>()
            .NavigateTo<ChangePasswordPage>("http://spe.sectorpensjon.net/PuST/Password/ChangePassword");

            //Action
            var ChangePwdWhenConfirmPwdIsNotMathNewPwd = ChangePasswordPage.SaveChangePwdForm("admin", "admin@123", "admin@111", "admin!123");

            //Assert
            Assert.AreEqual("The new password and confirmation password do not match.", ChangePwdWhenConfirmPwdIsNotMathNewPwd.ConfirmPwdIsNotMatchWithNewPwdErrorTextField);
        }
        /*
        //case5: change Pwd with a newPwd are similar with a currentPwd.
        [Test]
        public void ChangePwd_WithNewPwdIsSimilarWithCurrentPwd()
        {
            //Arrang
            var ChangePasswordPage = Threaded<Session>
           .With<Chrome>()
           .NavigateTo<ChangePasswordPage>("http://spe.sectorpensjon.net/PuST/Password/ChangePassword");

            //Action
            var ChangePwdWithNewPwdIsSimilarWithCurrentPwd = ChangePasswordPage.SaveChangePwdForm("admin", "admin@123", "admin@123", "admin@123");

            
            //Assert
            Assert.AreEqual("Confirm password change", ChangePwdWithNewPwdIsSimilarWithCurrentPwd);
        }
        */
    }


}
