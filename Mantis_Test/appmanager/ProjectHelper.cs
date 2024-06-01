using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Mantis_Test
{
    public class ProjectHelper
    {
        private IWebDriver driver;

        public ProjectHelper(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void GoToPageProject()
        {
            //GoToMenu();
            GoToSettings();
            GoToProjects();
        }

        public void AddProject(string v)
        {
            AddNewProject(v);
        }

        public void DeleteProject(string v)
        {
            GoToProject(v);
            Delete();                                    
        }

        private void Delete()
        {
            driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-white btn-round' and @formaction='manage_proj_delete.php']")).Click();
            driver.FindElement(By.CssSelector("input[type='submit'].btn.btn-primary.btn-white.btn-round")).Click();
        }

        public void GoToProject(string v)
        {
            driver.FindElement(
                                By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr[3]/td/a")
                                ).Click();
        }

        public void AddNewProject(string v)
        {
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            driver.FindElement(By.Id("project-name")).Click();
            driver.FindElement(By.Id("project-name")).Clear();
            driver.FindElement(By.Id("project-name")).SendKeys(v);
            driver.FindElement(By.CssSelector("input[type=\"submit\"].btn.btn-primary.btn-white.btn-round")).Click();
        }

        private void GoToProjects()
        {
            driver.FindElement(By.XPath("//a[@href=\"/mantisbt-2.26.2/mantisbt-2.26.2/manage_proj_page.php\"]")).Click();
        }

        private void GoToSettings()
        {
            driver.FindElement(By.XPath("//div[@id='sidebar']/ul/li[7]/a/i")).Click();
        }

        private void GoToMenu()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(driver =>
            {
                IWebElement elem = driver.FindElement(By.Id("menu-toggler"));
                if (elem != null && elem.Displayed)
                {
                    elem.Click();
                    return elem;
                }
                return null;
            });
        }

        public int GetProjectCount()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement projectTable = wait.Until(driver => driver.FindElement(By.XPath("//table[@class='table table-striped table-bordered table-condensed table-hover']/tbody")));
            IReadOnlyCollection<IWebElement> projectRows = projectTable.FindElements(By.TagName("tr"));
            Console.WriteLine("Number of project rows found: " + projectRows.Count);
            return projectRows.Count;
        }
    }
}