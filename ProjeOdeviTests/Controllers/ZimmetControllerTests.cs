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
    public class ZimmetControllerTests
    {
        private ChromeDriver WebDriver;
        private const string BaseAdres = "http://localhost:61525";
        [TestMethod()]
        public void ArizalandiTest()
        {
            WebDriver = new ChromeDriver();
            WebDriver.Navigate().GoToUrl(BaseAdres + "/Security/Login");
            WebDriver.FindElement(By.Name("KullaniciAdi")).SendKeys("faruksyhn");
            System.Threading.Thread.Sleep(3000);
            WebDriver.FindElement(By.Name("Sifre")).SendKeys("12345");
            System.Threading.Thread.Sleep(3000);
            WebDriver.FindElement(By.XPath("/html/body/div/div/div/form/button")).Click();
            System.Threading.Thread.Sleep(3000);
            WebDriver.FindElement(By.XPath("/html/body/div/nav[2]/div/ul/li[6]/a")).Click();
            System.Threading.Thread.Sleep(3000);
            WebDriver.FindElement(By.XPath("/html/body/div/div/div/div/div[2]/div/table/tbody/tr[2]/td[6]/a")).Click();
            System.Threading.Thread.Sleep(3000);
            WebDriver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/button[2]")).Click();
            System.Threading.Thread.Sleep(3000);

        }

        [TestMethod()]
        public void ParcaUrunZimmetleTest()
        {
            WebDriver = new ChromeDriver();
            WebDriver.Navigate().GoToUrl(BaseAdres + "/Security/Login");
            WebDriver.FindElement(By.Name("KullaniciAdi")).SendKeys("faruksyhn");
            System.Threading.Thread.Sleep(3000);
            WebDriver.FindElement(By.Name("Sifre")).SendKeys("12345");
            System.Threading.Thread.Sleep(3000);
            WebDriver.FindElement(By.XPath("/html/body/div/div/div/form/button")).Click();
            System.Threading.Thread.Sleep(3000);
            WebDriver.FindElement(By.XPath("/html/body/div/nav[2]/div/ul/li[5]/a")).Click();
            System.Threading.Thread.Sleep(3000);
            WebDriver.FindElement(By.XPath("/html/body/div/nav[2]/div/ul/li[5]/ul/li[1]/a")).Click();
            System.Threading.Thread.Sleep(3000);
            WebDriver.FindElement(By.Name("Tbl_Zimmet.UrunID")).SendKeys("Sony");
            System.Threading.Thread.Sleep(3000);
            WebDriver.FindElement(By.Name("Tbl_Zimmet.KullaniciID")).SendKeys("Furkan");
            System.Threading.Thread.Sleep(3000);
            WebDriver.FindElement(By.XPath("/html/body/div/div/form/div/div[2]/button")).Click();
            System.Threading.Thread.Sleep(3000);
        }
        
    }
}