using Bumblebee.Setup;
using Bumblebee.Setup.DriverEnvironments;
using demo_system_test.Page;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_system_test
{
    [TestFixture]
    public class LoginTestPageObject
    {
        [Test]
        public void Login_CorrectUsernameAndPassword_RedirectToProspectPage()
        {
            // Arrange
            var loginPage = Threaded<Session>
              .With<Chrome>()
              .NavigateTo<LoginPage>("http://spe.sectorpensjon.net/PuST/Login");

            // Act
            var prospectPage = loginPage.SubmitLoginForm("admin", "admin@123");

            // Assert
            Assert.NotNull(prospectPage.LogoutButton);
        }

        [Test]
        public void Login_InvalidUsernameAndPassword_DisplayErrorMsg()
        {
            // Arrange
            var loginPage = Threaded<Session>
              .With<Chrome>()
              .NavigateTo<LoginPage>("http://spe.sectorpensjon.net/PuST/Login");

            // Act
            var myProspectPage = loginPage.SubmitLoginForm("admin", "a");
            loginPage = new LoginPage(myProspectPage.Session);

            // Assert
            Assert.AreEqual("Feil brukernavn eller passord.", loginPage.SummaryErrorsMsg);
        }
    }
}
