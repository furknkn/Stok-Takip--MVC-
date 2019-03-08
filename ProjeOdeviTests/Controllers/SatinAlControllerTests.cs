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
    public class SatinAlControllerTests
    {
        private ChromeDriver WebDriver;
        private const string BaseAdres = "http://localhost:61525";
        [TestMethod()]
        public void ParcaUrunAlTest()
        {
            WebDriver = new ChromeDriver();
            WebDriver.Navigate().GoToUrl(BaseAdres + "/Security/Login");
            WebDriver.FindElement(By.Name("KullaniciAdi")).SendKeys("faruksyhn");
            System.Threading.Thread.Sleep(3000);
            WebDriver.FindElement(By.Name("Sifre")).SendKeys("12345");
            System.Threading.Thread.Sleep(3000);
            WebDriver.FindElement(By.XPath("/html/body/div/div/div/form/button")).Click();
            System.Threading.Thread.Sleep(3000);
            WebDriver.FindElement(By.XPath("/html/body/div/nav[2]/div/ul/li[2]/a")).Click();
            System.Threading.Thread.Sleep(3000);
            WebDriver.FindElement(By.Name("urun.Adi")).SendKeys("Sony");
            System.Threading.Thread.Sleep(3000);
            WebDriver.FindElement(By.Name("urun.BarkotNo")).SendKeys("99999");
            System.Threading.Thread.Sleep(3000);
            WebDriver.FindElement(By.Name("urun.KategoriID")).SendKeys("Rasm135234");
            System.Threading.Thread.Sleep(3000);
            WebDriver.FindElement(By.Name("urun.ToptanFiyat")).SendKeys("1200");
            System.Threading.Thread.Sleep(3000);
            WebDriver.FindElement(By.Name("urun.FirmaID")).SendKeys("B firması");
            System.Threading.Thread.Sleep(3000);
            WebDriver.FindElement(By.Name("urun.Adet")).SendKeys("2");
            System.Threading.Thread.Sleep(3000);
            WebDriver.FindElement(By.XPath("/html/body/div/div/form/div/div[2]/button")).Click();
            System.Threading.Thread.Sleep(3000);
        }

    }
}