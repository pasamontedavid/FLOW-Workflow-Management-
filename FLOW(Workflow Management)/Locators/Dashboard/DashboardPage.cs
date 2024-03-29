﻿using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLOW_Workflow_Management_.Locators.Dashboard
{
    public class DashboardPage
    {

        private IWebDriver driver;
        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        // Start Logout
        [FindsBy(How = How.CssSelector, Using = "a[title='userInfo.email'] img[alt='User profile picture']")]
        private IWebElement UserIcon;
        public IWebElement gotoUserIcon()
        {
            return UserIcon;
        }

        [FindsBy(How = How.CssSelector, Using = "span[data-i18n='drpdwn.page-logout']")]
        private IWebElement LogoutBtn;
        public IWebElement gotoLogoutBtn()
        {
            return LogoutBtn;
        }

        //END Logout


        //START ADMINISTRATOR MODULE
        [FindsBy(How = How.CssSelector, Using = "body > app-root:nth-child(3) > app-home:nth-child(3) > div:nth-child(1) > div:nth-child(1) > aside:nth-child(1) > ul:nth-child(3) > li:nth-child(2) > a:nth-child(1) > span:nth-child(2)")]
        private IWebElement Administrator;

        public IWebElement gotoAdministrator()
        {
            return Administrator;
        }


        //END ADMINISTRATOR MODULE

        //START ADMINISTRATOR SUB MODULE

        [FindsBy(How = How.CssSelector, Using = "a[title='/home/holiday-calendar']")]
        private IWebElement HolidayCalendar;
        public IWebElement gotoHolidayCalendar()
        {
            return HolidayCalendar;
        }


        [FindsBy(How = How.CssSelector, Using = "a[title='/home/reason']")]
        private IWebElement Reason;
        public IWebElement gotoReason()
        {
            return Reason;
        }

        [FindsBy(How = How.CssSelector, Using = "body > app-root:nth-child(3) > app-home:nth-child(3) > div:nth-child(1) > div:nth-child(1) > aside:nth-child(1) > ul:nth-child(3) > li:nth-child(2) > ul:nth-child(2) > li:nth-child(3) > a:nth-child(1) > span:nth-child(1)")]
        private IWebElement Workflow;
        public IWebElement gotoWorkflow()
        {
            return Workflow;
        }

        //END ADMINISTRATOR SUB MODULE










        //START USERMANAGEMENT MODULE

        [FindsBy(How =How.CssSelector, Using = "body > app-root:nth-child(3) > app-home:nth-child(3) > div:nth-child(1) > div:nth-child(1) > aside:nth-child(1) > ul:nth-child(3) > li:nth-child(3) > a:nth-child(1)")]
        private IWebElement USERMANGEMENT;

       

        
        public IWebElement gotoUSERMANAGEMENT()
        {
            return USERMANGEMENT;
        }
        //END USERMANAGEMENT MODULE
        // START USERMANAGEMENT Sub Module
        [FindsBy(How = How.CssSelector, Using = "a[title='/home/role']")]
        private IWebElement ROLE;
        public IWebElement gotoROLE()
        {
            return ROLE;
        }

        [FindsBy(How = How.CssSelector, Using = "a[title='/home/approval-level']")]
        private IWebElement APPROVALLEVELS;
        public IWebElement gotoAPPROVALLEVELS()
        {
            return APPROVALLEVELS;
        }


        [FindsBy(How = How.CssSelector, Using = "a[title='/home/pendingEmailVerification']")]
        private IWebElement PENDINGEMAILVERIFICATION;
        public IWebElement gotoPENDINGEMAILVERIFICATION()
        {
            return PENDINGEMAILVERIFICATION;
        }

        [FindsBy(How = How.CssSelector, Using = "a[title='/home/organizational-chart']")]
        private IWebElement ORGANIZATIONALSTUCTURES;
        public IWebElement gotoORGANIZATIONALSTUCTURES()
        {
            return ORGANIZATIONALSTUCTURES;
        }


        [FindsBy(How = How.CssSelector, Using = "a[title='/home/user/user-master']")]
        private IWebElement USERS;
        public IWebElement gotoUSERS()
        {
            return USERS;
        }


        //END USERMANAGEMENT Sub Module


        //START SYSTEMSETTINGS MODULE
        [FindsBy(How = How.CssSelector, Using = "body > app-root:nth-child(3) > app-home:nth-child(3) > div:nth-child(1) > div:nth-child(1) > aside:nth-child(1) > ul:nth-child(3) > li:nth-child(4) > a:nth-child(1) > span:nth-child(2)")]
        private IWebElement SystemSettings;
        public IWebElement gotoSystemSettings()
        {
            return SystemSettings;
        }

        //END SYSTEMSETTINGS MODULE

        //START SYSTEMSETTINGS SUB MODULE
        [FindsBy(How = How.CssSelector, Using = "body > app-root:nth-child(3) > app-home:nth-child(3) > div:nth-child(1) > div:nth-child(1) > aside:nth-child(1) > ul:nth-child(3) > li:nth-child(4) > ul:nth-child(2) > li:nth-child(1) > a:nth-child(1) > span:nth-child(1)")]
        private IWebElement Menu;
        public IWebElement gotoMenu()
        {
            return Menu;
        }

        [FindsBy(How = How.CssSelector, Using = "body > app-root:nth-child(3) > app-home:nth-child(3) > div:nth-child(1) > div:nth-child(1) > aside:nth-child(1) > ul:nth-child(3) > li:nth-child(4) > ul:nth-child(2) > li:nth-child(2) > a:nth-child(1) > span:nth-child(1)")]
        private IWebElement GlobalConfig;
        public IWebElement gotoGlobalConfig()
        {
            return GlobalConfig;
        }


        [FindsBy(How = How.CssSelector, Using = "body > app-root:nth-child(3) > app-home:nth-child(3) > div:nth-child(1) > div:nth-child(1) > aside:nth-child(1) > ul:nth-child(3) > li:nth-child(4) > ul:nth-child(2) > li:nth-child(3) > a:nth-child(1) > span:nth-child(1)")]
        private IWebElement Logs;
        public IWebElement gotoLogs()
        {
            return Logs;
        }

        //END SYSTEMSETTINGS SUB MODULE
    }
}
