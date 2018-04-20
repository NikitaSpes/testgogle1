using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.Threading;
using NUnit.Framework;

     



namespace GoogleTest
{
    [TestClass]
    public class UnitTest1
    {
        static IWebDriver Browser;
        static  WebDriverWait wait;

        [SetUp]
        public void start()
        {
            Browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            Browser.Manage().Window.Maximize();
            wait = new WebDriverWait(Browser, TimeSpan.FromSeconds(10));
        }

        public static bool IsElementExists(By iClassName)
        {

            try
            {
                Browser.FindElement(iClassName);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        [Test]
        public void TestMethod1()
        {
            Browser.Navigate().GoToUrl("https://www.google.ru/");
            if (IsElementExists(By.Id("lst-ib")) == true)
            {               
                    IsElementExists(By.Id("lst-ib"));
                    IWebElement Poisk = Browser.FindElement(By.Id("lst-ib"));
                    Poisk.SendKeys("selenium");
                    Poisk.SendKeys(OpenQA.Selenium.Keys.Enter);
                    wait.Until(ExpectedConditions.TitleIs("selenium - Поиск в Google"));                  
            }
        }
            

        [TearDown]
        public void stop()
        {
            Browser.Quit();
            Browser = null;
        }

    }
}
