using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;

namespace BankProject.Selenium
{
    [TestFixture]
    public class Basics
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            Console.WriteLine("Inside setup");
        }

        [Test(Author = "Manasa"), Order(2)]
        [TestCase("Hellow Manasa")]
        [Ignore("Ignore this test due to open bug")]
        public void Test1(string printText)
        {
            Console.WriteLine(printText);
            Console.WriteLine("Hello World");
            driver.Navigate().GoToUrl("https://www.google.com/");
            string title = driver.Title;
            Console.WriteLine("Title:" + title);
        }

        [Test(Author = "Manasa")]
        [TestCase("Hi Manasa")]
        public void First(string printText)
        {
            Console.WriteLine(printText);
            Console.WriteLine("Hello World");
            driver.Url="https://www.google.com/";
            string title = driver.Title;
            Console.WriteLine("Title:" + title);
            Console.WriteLine("URL:" + driver.Url);
        }

        [Test, Order(1)]
        public void Test2([Values("C# Selenium")] string text)
        {
            driver.Navigate().GoToUrl("https://www.google.com/");
            By searchBoxLocator = By.CssSelector("textarea#APjFqb");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(searchBoxLocator).SendKeys(text);
            driver.SwitchTo().ActiveElement().SendKeys(Keys.Enter);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Console.WriteLine("Inside teardown");
            driver.Quit();
            driver = null;
        }
    }
}