using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLOW_Workflow_Management_.Locators.UserManagement
{
    public class ApprovalLevelsPage
    {
        private IWebDriver driver;

        public ApprovalLevelsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //START NAVIGATIONS
        [FindsBy(How = How.CssSelector, Using = ".nav-pills li:nth-child(1)")]
        private IWebElement AllNav;

        public IWebElement gotoAllNav()
        {
            return AllNav;
        }

        [FindsBy(How = How.CssSelector, Using = ".nav-pills li:nth-child(2)")]
        private IWebElement GroupNav;

        public IWebElement gotoGroupNav()
        {
            return GroupNav;
        }

        [FindsBy(How = How.CssSelector, Using = ".nav-pills li:nth-child(3)")]
        private IWebElement DepartmentNav;

        public IWebElement gotoDepartmentNav()
        {
            return DepartmentNav;
        }

        [FindsBy(How = How.CssSelector, Using = ".nav-pills li:nth-child(4)")]
        private IWebElement SectionNav;

        public IWebElement gotoSectionNav()
        {
            return SectionNav;
        }

        [FindsBy(How = How.CssSelector, Using = ".nav-pills li:nth-child(5)")]
        private IWebElement UnitNav;

        public IWebElement gotoUnitNav()
        {
            return UnitNav;
        }

        //END NAVIGATIONS

        //Approval LEVEL
        [FindsBy(How = How.CssSelector, Using = "select[formcontrolname='ApprovalLevelId']")]
        private IWebElement ApprovalLevel;

        public IWebElement gotoApprovalLevel()
        {
            return ApprovalLevel;
        }
        //Published
        [FindsBy(How = How.CssSelector, Using = "select[formcontrolname = 'Published']")]
        private IWebElement Published;

        public IWebElement gotoPublished()
        {
            return Published;
        }

        //CLOSE BUTTON
        [FindsBy(How = How.CssSelector, Using = ".fal.fa-window-close")]
        private IWebElement Close;

        public IWebElement gotoClose()
        {
            return Close;
        }

        //SAVE BUTTON
        [FindsBy(How = How.CssSelector, Using = "button[type='submit']")]
        private IWebElement Save;

        public IWebElement gotoSave()
        {
            return Save;
        }

    }
}
