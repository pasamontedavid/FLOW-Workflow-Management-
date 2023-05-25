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
            this.driver.Value.FindElement(By.CssSelector("input[placeholder='Email']")).SendKeys(email);
            this.driver.Value.FindElement(By.CssSelector("input[placeholder='Password']")).SendKeys(pwd);
            this.driver.Value.FindElement(By.Id("js-login-btn")).Click();
        }
        
        public void Logout()
        {
            driver.Value.FindElement(By.CssSelector("a[title='userInfo.email'] img[alt='User profile picture']")).Click();
            driver.Value.FindElement(By.CssSelector("span[data-i18n='drpdwn.page-logout']")).Click();

        }



        public void confirmDelete()
        {
            driver.Value.FindElement(By.CssSelector("button[class='swal2-confirm swal2-styled swal2-default-outline']")).Click();
        }

        public void canceldelete()
        {
            driver.Value.FindElement(By.CssSelector("button[class='swal2-cancel swal2-styled swal2-default-outline']")).Click();
        }

    }
}
