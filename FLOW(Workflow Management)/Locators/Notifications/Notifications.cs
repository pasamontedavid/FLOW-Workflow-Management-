using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLOW_Workflow_Management_.Locators.Notifications
{
    public class Notifications
    {

        private IWebDriver driver;

        public Notifications(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".toast-message")]
        private IWebElement NotifMsg;
        public IWebElement gotoNotifMsg()
        {
            return NotifMsg;
        }

        [FindsBy(How = How.CssSelector, Using = ".toast-title")]
        private IWebElement NotifTitle;
        public IWebElement gotoNotifTitle()
        {
            return NotifTitle;
        }

        [FindsBy(How = How.CssSelector, Using = "#swal2-title")]
        private IWebElement PopupTitle;
        public IWebElement gotoPopupTitle()
        {
            return PopupTitle;
        }

        [FindsBy(How = How.CssSelector, Using = "#swal2-html-container")]
        private IWebElement PopupMsg;
        public IWebElement gotoPopupMsg()
        {
            return PopupMsg;
        }

        

    }
}
