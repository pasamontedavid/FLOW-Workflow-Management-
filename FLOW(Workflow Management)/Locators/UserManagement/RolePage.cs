using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLOW_Workflow_Management_.Locators.UserManagement
{
    public class RolePage
    {

        private IWebDriver driver;

        public RolePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.CssSelector, Using = ".btn.btn-primary.float-right")]
        private IWebElement Create;
        public IWebElement gotoCreate()
        {
            return Create;
        }

        [FindsBy(How = How.CssSelector, Using = "input[placeholder='Role Name']")]
        private IWebElement RoleTxtbx;
        public IWebElement gotoRoleTxtbx()
        {
            return RoleTxtbx;
        }


        [FindsBy(How = How.CssSelector, Using = "select[class='form-control form-control-sm ng-untouched ng-pristine ng-invalid']")]
        private IWebElement IndexDropdown;
        public IWebElement gotoIndexDropdown()
        {
            return IndexDropdown;
        }

        [FindsBy(How = How.CssSelector, Using = ".form-control.form-control-sm.ng-pristine.ng-valid.ng-untouched")]
        private IWebElement PublishedDropdown;
        public IWebElement gotoPublishedDropdown()
        {
            return PublishedDropdown;
        }


        [FindsBy(How = How.CssSelector, Using = "button[type='submit']")]
        private IWebElement Save;
        public IWebElement gotoSave()
        {
            return Save;
        }

        [FindsBy(How = How.CssSelector, Using = "input[type='search']")]
        private IWebElement Search;
        public IWebElement gotoSearch()
        {
            return Search;
        }


        [FindsBy(How = How.CssSelector, Using = "tbody tr:nth-child(1) td:nth-child(6) div:nth-child(1) a:nth-child(1) i:nth-child(1)")]
        private IWebElement firstedit;
        public IWebElement goto1stEdit()
        {
            return firstedit;
        }

        [FindsBy(How = How.CssSelector, Using = "a[title='Delete'] i[class='fal fa-times']")]
        private IWebElement firstdelete;
        public IWebElement goto1stDelete()
        {
            return firstdelete;
        }

    }
}
