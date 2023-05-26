using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using OpenQA.Selenium.Interactions;
using System.Security.Cryptography.X509Certificates;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using Microsoft.Extensions.Options;
using FLOW_Workflow_Management_.Locators.Login;
using FLOW_Workflow_Management_.Locators.Dashboard;
using FLOW_Workflow_Management_.Locators.Notifications;

namespace FLOW_Workflow_Management_.Utilities
{
    public class BaseConfig
    {
        public ExtentReports EXTENTREPORTS;
        public ExtentTest test;
        public String targetproject = "";

        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        //report
        [OneTimeSetUp]
        public void reportSetup()
        {
            string WorkDirectory = Environment.CurrentDirectory;
            string ProjectDirectory = Directory.GetParent(WorkDirectory).Parent.Parent.FullName;
            string TestreportPATH = ProjectDirectory + "//TestReport.html";
            var htmlReporter = new ExtentHtmlReporter(TestreportPATH);
            EXTENTREPORTS = new ExtentReports();
            EXTENTREPORTS.AttachReporter(htmlReporter);
            EXTENTREPORTS.AddSystemInfo("Name", "FLOW(Workflow Management)");
            EXTENTREPORTS.AddSystemInfo("Host Name", "http://flow.sit.federalland.ph/");
            EXTENTREPORTS.AddSystemInfo("Environtment", "SIT");
            EXTENTREPORTS.AddSystemInfo("Tester", "David Philip Pasamonte");

        }


        [SetUp]
        public void OpenBrowser()
        {
            test = EXTENTREPORTS.CreateTest(TestContext.CurrentContext.Test.Name);
            //setup chrome driver 
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("window-size=1920,1080");
            //chromeOptions.AddArguments("headless");
            driver.Value = new ChromeDriver(ChromeDriverService.CreateDefaultService(), chromeOptions, TimeSpan.FromMinutes(3));

            driver.Value.Manage().Window.Maximize();
            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Value.Url = "http://flow.sit.federalland.ph/";
        }



        [TearDown]
        public void close()
        {
            var testresult = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = TestContext.CurrentContext.Result.StackTrace;
            var Messagelog = TestContext.CurrentContext.Result.Message;
            String filename = "Screenshot" + DateTime.Now.ToString("h_mm_ss") + ".png";
            if (testresult == TestStatus.Failed)
            {
                test.Fail("TEST FAILED", captureScreenShot(driver.Value, filename));
                test.Log(Status.Info, "LOGTRACE" + stacktrace);
                if (Messagelog != null)
                {
                    test.Log(Status.Fail, "Message: " + Messagelog);
                }
            }
            else if (testresult == TestStatus.Passed)
            {
                test.Pass("TEST PASSED", captureScreenShot(driver.Value, filename));
                if (Messagelog != null)
                {
                    test.Log(Status.Pass, "Message: " + Messagelog);
                }
            }
            Thread.Sleep(3000);
            EXTENTREPORTS.Flush();
            Logout();
            driver.Value.Quit();

        }

        //Report Screenshot
        public MediaEntityModelProvider captureScreenShot(IWebDriver driver, String ScreenshotName)
        {

            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, ScreenshotName).Build();
        }


        public void Login(String email,String pwd)
        {
            LoginPage login = new LoginPage(driver.Value);

            login.gotoLoginID().SendKeys(email);
            login.gotoPassword().SendKeys(pwd);
            login.gotoSubmit().Click();
        }
        
        public void Logout()
        {

            DashboardPage dashboard = new DashboardPage(driver.Value);
            dashboard.gotoUserIcon().Click();
            dashboard.gotoLogoutBtn().Click();

        }



        public void confirmDelete()
        {
            Notifications notifications = new Notifications(driver.Value);


            notifications.gotoConfirmDelete().Click();
        }

        public void canceldelete()
        {
            Notifications notifications = new Notifications(driver.Value);
            notifications.gotoCancelDelete().Click();
        }

    }
}
