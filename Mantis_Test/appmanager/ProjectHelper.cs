using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;


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
            GoToSettings();
            GoToProjects();
        }

        private void GoToSettings()
        {
            driver.FindElement(By.XPath("//div[@id='sidebar']/ul/li[7]/a/i")).Click();
        }

        private void GoToProjects()
        {
            driver.FindElement(By.XPath("//a[@href=\"/mantisbt-2.26.2/mantisbt-2.26.2/manage_proj_page.php\"]")).Click();
        }


        public void AddProject(string v)
        {
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            driver.FindElement(By.Id("project-name")).Click();
            driver.FindElement(By.Id("project-name")).Clear();
            driver.FindElement(By.Id("project-name")).SendKeys(v);
            driver.FindElement(By.CssSelector("input[type=\"submit\"].btn.btn-primary.btn-white.btn-round")).Click();
        }

        public void DeleteProject(string v)
        {
            PrintAllProjectLinks();
            int projectIndex = FindProjectIndex(v);
            GoToProjectByIndex(projectIndex);
            Delete(); 
        }

        public void Delete()
        {
            driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-white btn-round' and @formaction='manage_proj_delete.php']")).Click();
            driver.FindElement(By.CssSelector("input[type='submit'].btn.btn-primary.btn-white.btn-round")).Click();
        }


        public int FindProjectIndex(string projectName)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.XPath("//table[@class='table table-striped table-bordered table-condensed table-hover']/tbody")));
            IReadOnlyCollection<IWebElement> projectLinks = driver.FindElements(By.XPath("//table[@class='table table-striped table-bordered table-condensed table-hover']/tbody/tr/td/a"));
            List<IWebElement> projectLinksList = projectLinks.ToList();

            // Ищем проект по имени и возвращаем его индекс
            for (int i = 0; i < projectLinksList.Count; i++)
            {
                if (projectLinksList[i].Text.Trim() == projectName)
                {
                    return i;
                }
            }
            // Если проект не найден, возвращаем -1
            return -1;
        }

        public void PrintAllProjectLinks()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.XPath("//table[@class='table table-striped table-bordered table-condensed table-hover']/tbody")));
            IReadOnlyCollection<IWebElement> projectLinks = driver.FindElements(
                By.XPath("//table[@class='table table-striped table-bordered table-condensed table-hover']/tbody/tr/td/a"));
        }

        public void GoToProjectByIndex(int projectIndex)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                wait.Until(d => d.FindElement(By.XPath("//table[@class='table table-striped table-bordered table-condensed table-hover']/tbody")));
                IReadOnlyCollection<IWebElement> projectLinks = driver.FindElements(
                    By.XPath("//table[@class='table table-striped table-bordered table-condensed table-hover']/tbody/tr/td/a"));
                if (projectIndex >= 0 && projectIndex < projectLinks.Count)
                {
                    // Переход по индексу
                    projectLinks.ElementAt(projectIndex).Click();
                }
                else
                {
                    throw new NoSuchElementException($"Index '{projectIndex}' is out of bounds.");
                }
            }
            catch (NoSuchElementException)
            {
                throw new NoSuchElementException("Project link not found.");
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while navigating to project: {ex.Message}", ex);
            }
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
    }
}