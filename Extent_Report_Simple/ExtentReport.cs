using AventStack.ExtentReports.Reporter.Configuration;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Edge;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Extent_Report_Simple
{
    public class ExtentReport
    {
        public static ExtentReports extentReports;
        public static ExtentTest exParentTest;
        public static ExtentTest exChildTest;
        public static string dirpath;

        public static void LogReport(string testcase)
        {
            extentReports = new ExtentReports();

            dirpath = @"..\..\TestExecutionReports\" + '_' + testcase;

            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(dirpath);

            htmlReporter.Config.Theme = Theme.Standard;

            extentReports.AttachReporter(htmlReporter);
        }

        public void TakeScreenshot(IWebDriver driver, Status status, string stepDetail)
        {

            string path = @"C:\Users\mt\source\repos\Extent_Report_Simple\Extent_Report_Simple\bin\Screenshot\" + "TestExecLog_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            Screenshot image_username = ((ITakesScreenshot)driver).GetScreenshot();
            image_username.SaveAsFile(path + ".png", ScreenshotImageFormat.Png);
            ExtentReport.exChildTest.Log(status, stepDetail, MediaEntityBuilder
                .CreateScreenCaptureFromPath(path + ".png").Build());


        }

        public void Write(IWebDriver driver, By by, string data, string detail)
        {
            try
            {
                driver.FindElement(by).SendKeys(data);
                TakeScreenshot(driver, Status.Pass, detail);
            }
            catch (Exception ex)
            {
                TakeScreenshot(driver, Status.Fail, "Entry Failed" + ex);
            }
        }

        public void Click(IWebDriver driver, By by, string detail)
        {
            try
            {
                driver.FindElement(by).Click();
                TakeScreenshot(driver, Status.Pass, detail);
            }
            catch (Exception ex)
            {
                TakeScreenshot(driver, Status.Fail, "Entry Failed" + ex);
            }
        }


    }
}
