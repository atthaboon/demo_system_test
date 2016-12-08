using Bumblebee.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bumblebee.Setup;
using OpenQA.Selenium;
using Bumblebee.Interfaces;

namespace demo_system_test.Page
{
    public class LoginPage : Block
    {
        public LoginPage(Session session) : base(session)
        {
            Tag = Session.Driver.FindElement(By.TagName("body"));
        }

        private ITextField<LoginPage> UsernameField
        {
            get { return new TextField<LoginPage>(this, By.Id("UserName")); }
        }

        private ITextField<LoginPage> PasswordField
        {
            get { return new TextField<LoginPage>(this, By.Id("Password")); }
        }

        private IClickable<MyProspectPage> LoginButton
        {
            get { return new Clickable<MyProspectPage>(this, By.Name("loginForm")); }
        }

        public String SummaryErrorsMsg
        {
            get { return FindElement(By.ClassName("validation-summary-errors")).Text; }
        }


        public MyProspectPage SubmitLoginForm(string username, string password)
        {
            return UsernameField.EnterText(username)
                .PasswordField.EnterText(password)
                .LoginButton.Click();
        }

    }
}
