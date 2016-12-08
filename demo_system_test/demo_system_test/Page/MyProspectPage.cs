using Bumblebee.Implementation;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bumblebee.Setup;
using Bumblebee.Interfaces;
using OpenQA.Selenium;

namespace demo_system_test.Page
{
    public class MyProspectPage : Block
    {
        public MyProspectPage(Session session) : base(session)
        {
            Tag = Session.Driver.FindElement(By.TagName("body"));
        }

        public IClickable<MyProspectPage> LogoutButton
        {
            get { return new Clickable<MyProspectPage>(this, By.Id("login-btn")); }
        }

    }
}
