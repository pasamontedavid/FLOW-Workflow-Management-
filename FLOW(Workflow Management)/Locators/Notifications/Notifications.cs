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

        // START NOTIFICATIONS

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

        // END NOTIFICATIONS


        // START POP-UP MODAL

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
        // END POP-UP MODAL


        //START Delete MODAL 
        [FindsBy(How = How.CssSelector,Using = "button[class='swal2-confirm swal2-styled swal2-default-outline']")]
        private IWebElement ConfirmDelete;
        public IWebElement gotoConfirmDelete()
        {
            return ConfirmDelete;
        }

        [FindsBy(How = How.CssSelector, Using = "button[class='swal2-cancel swal2-styled swal2-default-outline']")]
        private IWebElement CancelDelete;

        public IWebElement gotoCancelDelete()
        {
            return CancelDelete;
        }



        //END Delete MODAL 

    }
}
