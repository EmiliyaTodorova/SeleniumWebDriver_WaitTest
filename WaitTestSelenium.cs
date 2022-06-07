using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace SeleniumAdvancedAndPOM
{
    public class WaitTestsSelenium
    {
        private WebDriver driver;
        private WebDriverWait wait;

        public System.TimeSpan Timespan { get; private set; }

        [TearDown]
        public void TearDown()
        {
        driver.Quit();
        }

        [Test]
        public void Test_Wait_ThreadSleep()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://www.uitestpractice.com/students/Contact";
            var element = driver.FindElement(By.PartialLinkText("This is"));
            element.Click();
            Thread.Sleep(15000);
            var textElement = driver.FindElement(By.ClassName("ContactUs")).Text;

            Assert.IsNotEmpty(textElement);
            

        }
        [Test]
        public void Test_ImpliciteWait()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.Url = "http://www.uitestpractice.com/students/Contact";
            driver.FindElement(By.PartialLinkText("This is")).Click();
                       
            var textElement = driver.FindElement(By.ClassName("ContactUs")).Text;

            Assert.IsNotEmpty(textElement);
        }
        [Test]
        public void Test_ExpliciteWait()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            driver.Url = "http://www.uitestpractice.com/students/Contact";
            driver.FindElement(By.PartialLinkText("This is")).Click();

            var text_element =this.wait.Until(d=>
            {
                return d.FindElement(By.ClassName("ContactUs")).Text;
            });
            Assert.IsNotEmpty(text_element);
            }

        [Test]
        public void Test_Wait_ExpectedConditions()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            driver.Url = "http://www.uitestpractice.com/students/Contact";
            driver.FindElement(By.PartialLinkText("This is")).Click();

            var text_element = this.wait.Until(
                ExpectedConditions.ElementIsVisible(By.ClassName("ContactUs"))
            );

            Assert.IsNotEmpty(text_element.Text);
        }
    }
}
