﻿using FLOW_Workflow_Management_.Locators.Dashboard;
using FLOW_Workflow_Management_.Locators.UserManagement;
using FLOW_Workflow_Management_.Utilities;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.Client;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLOW_Workflow_Management_.TestItems.UserManagement
{
    public class Role:BaseConfig
    {
        
        [Test]
        [TestCase("dpppasamonte@federalland.ph", "Admin123", "Automation Testing","Active", "/home/index")]
        public void CreateROLE(String email, String pwd, String rolename, String published, String indexval)
        {
            Login(email, pwd);
            DashboardPage dashboard = new DashboardPage(driver.Value);

            dashboard.gotoUSERMANAGEMENT().Click();
            dashboard.gotoROLE().Click();

            RolePage role= new RolePage(driver.Value);

            role.gotoCreate().Click();
            role.gotoRoleTxtbx().SendKeys(rolename);

            //INDEX DROPOWN
            SelectIndex(indexval);

            //PUBLISHED DROPDOWN
            SelectPublished(published);

            role.gotoSave().Click();
        }




        public void EditROLE(String email, String pwd, String rolename, String published, String indexval, String NEWrolename, String NEWpublished, String NEWindexval)
        {
            Login(email, pwd);
            RolePage role = new RolePage(driver.Value);
            role.gotoSearch().SendKeys(rolename);
            role.goto1stEdit().Click();

            if(NEWrolename != "")
            {
                role.gotoRoleTxtbx().SendKeys(rolename);
            }

            if(NEWpublished != "")
            {
                SelectIndex(NEWpublished);
            }

            if(NEWindexval != "")
            {
                SelectIndex(NEWindexval);
            }

            role.gotoSave().Click();


        }








        //SELECT INDEX FUNCTION
        public void SelectIndex(String indexval)
        {
            RolePage role = new RolePage(driver.Value);

            IWebElement indexes = role.gotoIndexDropdown();
            SelectElement indexdd = new SelectElement(indexes);
            indexdd.SelectByText(indexval);
        }

        public void SelectPublished(String published)
        {
            RolePage role = new RolePage(driver.Value);
            IWebElement publishes = role.gotoPublishedDropdown();
            SelectElement publishdd = new SelectElement(publishes);
            publishdd.SelectByText(published);
        }

    }
}
