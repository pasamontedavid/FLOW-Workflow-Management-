using FLOW_Workflow_Management_.Locators.Login;
using FLOW_Workflow_Management_.Locators.Notifications;
using FLOW_Workflow_Management_.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLOW_Workflow_Management_.TestItems.Login
{
    public class Login:BaseConfig
    {
        [Test]
        [TestCase("dpppasamonte@federalland.ph","Admin123")]
        public void LoginHappyPath(String email, String pwd)
        {
            Notifications notification = new Notifications(driver.Value);

            LoginPage loginpage = new LoginPage(driver.Value);
            loginpage.gotoLoginID().SendKeys(email);
            loginpage.gotoPassword().SendKeys(pwd);
            loginpage.gotoSubmit().Click();
            StringAssert.Contains(email,notification.gotoNotifMsg().Text);
        }
    }
}
