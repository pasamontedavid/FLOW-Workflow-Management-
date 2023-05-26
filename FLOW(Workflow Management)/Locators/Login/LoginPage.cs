using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FLOW_Workflow_Management_.Locators.Login
{
    public class LoginPage
    {

        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //USERID/LoginID
        [FindsBy(How = How.CssSelector, Using = "input[placeholder='Email']")]
        private IWebElement LoginID;
        public IWebElement gotoLoginID()
        {
            return LoginID;
        }


        //PASSWORD
        [FindsBy(How = How.CssSelector, Using = "input[placeholder='Password")]
        private IWebElement Password;
        public IWebElement gotoPassword()
        {
            return Password;
        }

        //Login BUTTON

        [FindsBy(How = How.Id, Using = "js-login-btn")]
        private IWebElement Submit;
        public IWebElement gotoSubmit()
        {
            return Submit;
        }


      

    }
}
