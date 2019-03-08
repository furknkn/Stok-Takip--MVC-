using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjeOdevi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ProjeOdevi.Controllers.Tests
{
    [TestClass()]
    public class StokControllerTests
    {
        private ChromeDriver WebDriver;
        private const string BaseAdres = "http://localhost:61525";
        [TestMethod()]
        public void ArizaliUrunlerTest()
        {
            WebDriver = new ChromeDriver();
            WebDriver.Navigate().GoToUrl(BaseAdres + "/Security/Login");
            WebDriver.FindElement(By.Name("KullaniciAdi")).SendKeys("faruksyhn");
            System.Threading.Thread.Sleep(3000);
            WebDriver.FindElement(By.Name("Sifre")).SendKeys("12345");
            System.Threading.Thread.Sleep(3000);
            WebDriver.FindElement(By.XPath("/html/body/div/div/div/form/button")).Click();
            System.Threading.Thread.Sleep(3000);
            WebDriver.FindElement(By.XPath("/html/body/div/nav[2]/div/ul/li[4]/a/i")).Click();
            System.Threading.Thread.Sleep(3000);
        }
    }
}