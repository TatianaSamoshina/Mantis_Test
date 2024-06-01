using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Mantis_Test
{
    [TestFixture]
    public class ProjectTests : TestBase
    {
        [Test]
        public void AddProjectTest()
        {
            projectHelper.GoToPageProject();
            int projectCountBefore = projectHelper.GetProjectCount();
            Console.WriteLine("Projects before adding: " + projectCountBefore);

            projectHelper.AddProject("t2");
            Thread.Sleep(2000);

            int projectCountAfter = projectHelper.GetProjectCount();
            Console.WriteLine("Projects after adding: " + projectCountAfter);
            Assert.AreEqual(projectCountBefore + 1, projectCountAfter);
        }

        [Test]
        public void DeleteProjectTest()
        {
            projectHelper.GoToPageProject();
            int projectCountBefore = projectHelper.GetProjectCount();
            Console.WriteLine("Projects before adding: " + projectCountBefore);

            projectHelper.DeleteProject("t2");

            int projectCountAfter = projectHelper.GetProjectCount();
            Console.WriteLine("Projects after adding: " + projectCountAfter);
            Assert.AreEqual(projectCountBefore - 1, projectCountAfter);
        }
    }
}
