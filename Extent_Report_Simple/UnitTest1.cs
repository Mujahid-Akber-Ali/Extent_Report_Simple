using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Threading;

namespace Extent_Report_Simple
{
    [TestClass]
    public class UnitTest1 :ExtentReport
    {
        [TestMethod]
        public void TestMethod1()
        {
            LogReport("Testing");

            exParentTest = extentReports.CreateTest("Simple Extent Report");

            exChildTest = exParentTest.CreateNode("Login");

            IWebDriver driver = new EdgeDriver();

            driver.Url = "https://www.saucedemo.com/v1/index.html";
            //driver.FindElement(By.XPath("/html/body/div[2]/div[1]/div/div/form/input[1]")).SendKeys("standard_user");
            //TakeScreenshot(driver, Status.Pass, "Enter Username");

            Write(driver, By.XPath("/html/body/div[2]/div[1]/div/div/form/input[1]"), "standard_user", "Enter Username");

            //driver.FindElement(By.XPath("/html/body/div[2]/div[1]/div/div/form/input[2]")).SendKeys("secret_sauce");
            //TakeScreenshot(driver, Status.Pass, "Enter Password");
            Write(driver, By.XPath("/html/body/div[2]/div[1]/div/div/form/input[2]"), "secret_sauce", "Enter Password");

            //driver.FindElement(By.XPath("/html/body/div[2]/div[1]/div/div/form/input[3]")).Click();
            //TakeScreenshot(driver, Status.Pass, "Click Submit");
            Click(driver, By.XPath("/html/body/div[2]/div[1]/div/div/form/input[3]"), "CLick Submit");
            Thread.Sleep(1000);

            exChildTest = exParentTest.CreateNode("Add to cart");

            //driver.FindElement(By.XPath("/html/body/div/div[2]/div[2]/div/div[2]/div/div[1]/div[3]/button")).Click();
            //TakeScreenshot(driver, Status.Pass, "Adding add to cart");

            Click(driver, By.XPath("/html/body/div/div[2]/div[2]/div/div[2]/div/div[1]/div[3]/button"), "CLick item");

            extentReports.Flush();
            driver.Close();

        }
    }
}
