using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace Mantis_Test
{
    public class LoginHelper
    {
        private IWebDriver driver;

        public LoginHelper(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Login(string username, string password)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement usernameField = driver.FindElement(By.Name("username"));
            usernameField.SendKeys(username);
            usernameField.SendKeys(Keys.Enter);
            IWebElement passwordField = null;
            while (passwordField == null)
            {
                try { passwordField = driver.FindElement(By.Name("password")); }
                catch (NoSuchElementException) { System.Threading.Thread.Sleep(1000); }
            }
            passwordField.SendKeys(password);
            passwordField.SendKeys(Keys.Enter);
        }
    }
}