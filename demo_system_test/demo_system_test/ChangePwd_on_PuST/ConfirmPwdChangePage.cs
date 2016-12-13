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
    public class ConfirmChangePasswordPage : Block
    {
        public ConfirmChangePasswordPage(Session session) : base(session)
        {
            Tag = Session.Driver.FindElement(By.TagName("body"));
        }

        public ITextField<ConfirmChangePasswordPage> ConfirmTextField
        {
            get { return new TextField<ConfirmChangePasswordPage>(this, By.ClassName("content-wrapper main-content clear-fix")); }
        }
    }
}