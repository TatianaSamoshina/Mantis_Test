using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Mantis_Test
{
    public class TestBase
    {
        protected IWebDriver driver;
        protected LoginHelper loginHelper;
        protected ProjectHelper projectHelper;
        protected string baseUrl = "http://localhost/mantisbt-2.26.2/mantisbt-2.26.2/login_page.php";

        public TestBase()
        {
            driver = new ChromeDriver();
            loginHelper = new LoginHelper(driver);
            projectHelper = new ProjectHelper(driver);
        }

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl(baseUrl);
            loginHelper.Login("administrator", "root");
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }

}