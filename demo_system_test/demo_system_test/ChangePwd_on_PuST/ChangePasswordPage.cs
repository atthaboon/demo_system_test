using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_system_test.ChangePwd_on_PuST
{
    public class ChangePasswordPage : Block
    {
        public ChangePasswordPage(Session session) : base(session)
        {
            Tag = Session.Driver.FindElement(By.TagName("body"));
        }

        private ITextField<ChangePasswordPage> UserNameField
        {
            get { return new TextField<ChangePasswordPage>(this, By.Id("UserName")); }
        }

        
        private ITextField<ChangePasswordPage> CurrentPasswordField
        {
            get { return new TextField<ChangePasswordPage>(this, By.Id("CurrentPassword")); }
        }

        private ITextField<ChangePasswordPage> NewPasswordField
        {
            get { return new TextField<ChangePasswordPage>(this, By.Id("NewPassword")); }
        }

        private ITextField<ChangePasswordPage> ConfirmPasswordField
        {
            get { return new TextField<ChangePasswordPage>(this, By.Id("ConfirmPassword")); }

        }

        private IClickable<ChangePasswordPage> SaveBtn
        {
            get { return new Clickable<ChangePasswordPage>(this, By.Id("btnSubmit")); }
        }


        public string ErrorMsgWhenNotEntUsername
        {
            get { return FindElement(By.Id("UserName-error")).Text; }
        }

        public string CurrentPasswordErrorTextField => FindElement(By.Id("CurrentPassword-error")).Text;

        public string NewPasswordErrorTextField => FindElement(By.Id("NewPassword-error")).Text;

        public string ConfirmPasswordErrorTextField => FindElement(By.Id("ConfirmPassword-error")).Text;

        public string CurrentPasswordIsInvalidTextField => FindElement(By.Id("CurrentPasswordValidationMessage")).Text;

        public string ConfirmPwdIsNotMatchWithNewPwdErrorTextField => FindElement(By.Id("ConfirmPassword-error")).Text;

        
        public ChangePasswordPage SaveChangePwdForm(string username, string currentpassword, string newpassword, string confirmpassword)
        {
            return UserNameField.EnterText(username)
                .CurrentPasswordField.EnterText(currentpassword)
                .NewPasswordField.EnterText(newpassword)
                .ConfirmPasswordField.EnterText(confirmpassword)
                .SaveBtn.Click();
        }

    }
}
