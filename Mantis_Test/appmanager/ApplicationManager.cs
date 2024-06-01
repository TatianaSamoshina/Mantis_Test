using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using static System.Net.WebRequestMethods;
using OpenQA.Selenium.Chrome;


namespace Mantis_Test
{
    /*public class ApplicationManager
    {
        private IWebDriver driver;
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        public ApplicationManager()
        {
            driver = new ChromeDriver();
        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                app.Value = new ApplicationManager();
            }
            return app.Value;
        }

        public void Stop()
        {
            try { driver.Quit(); }
            catch (Exception) { }
        }

        public LoginHelper Auth => new LoginHelper(driver);
        public ProjectHelper Project => new ProjectHelper(driver);

        public IWebDriver Driver => driver;
    }*/
}