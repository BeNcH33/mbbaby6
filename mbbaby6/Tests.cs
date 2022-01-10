using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbbaby6
{
    class Tests
    {
        private IWebDriver driver;
        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
        }
        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }
        [Test]
        public void opensite()
        {
            driver.Navigate().GoToUrl("https://www.wildberries.ru");
            driver.Manage().Window.Size = new System.Drawing.Size(1366, 768);
            System.Threading.Thread.Sleep(1000);

        }

        [Test]
        public void searchonsite()
        {
            driver.Navigate().GoToUrl("https://www.wildberries.ru");
            driver.Manage().Window.Size = new System.Drawing.Size(1366, 768);
            driver.FindElement(By.CssSelector("#searchInput")).Click();
            driver.FindElement(By.CssSelector("#searchInput")).SendKeys("iphone");
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("#searchInput")).SendKeys(Keys.Enter);
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(".nav-element__logo")).Click();
            driver.FindElement(By.CssSelector("#searchInput")).SendKeys("");
            driver.FindElement(By.CssSelector("#searchInput")).SendKeys("Кросовки Nike");
            System.Threading.Thread.Sleep(1000);
        }


        [Test]
        public void nothingmatches()
        {
            driver.Navigate().GoToUrl("https://www.wildberries.ru");
            driver.Manage().Window.Size = new System.Drawing.Size(1366, 768);

            driver.FindElement(By.CssSelector("#searchInput")).Click();
            driver.FindElement(By.CssSelector("#searchInput")).SendKeys("якнчсиротлб");
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("#searchInput")).SendKeys(Keys.Enter);
            System.Threading.Thread.Sleep(1000);
            driver.FindElements(By.CssSelector("p.catalog-page--non-search"));
            System.Threading.Thread.Sleep(1000);
        }
    }
}
