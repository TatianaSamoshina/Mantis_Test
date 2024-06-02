using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;

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

        [Test]
        public void AddProjectTestAPI()
        {
            AccountData account = new AccountData("administrator", "root");
            ProjectData pname = new ProjectData("testproject");
            APIHelper api = new APIHelper();

            // Если есть проект - сначала удаляем
            if (api.IsProjectExist(account, pname))
            {
                api.DeleteProject(account, pname);
            }

            // Добавляем проект
            api.AddNewProject(account, pname);

            // Проверка
            if (!api.IsProjectExist(account, pname))
            {
                throw new Exception("Project was not added successfully.");
            }
        }

        [Test]
        public void DeleteProjectTestAPI() 
        {
            AccountData account = new AccountData("administrator", "root");
            ProjectData pname = new ProjectData("testproject");
            APIHelper api = new APIHelper();

            // Проверяем что проект есть
            bool projectExists = api.IsProjectExist(account, pname);

            // Если нет - создаем его
            if (!projectExists)
            {
                api.AddNewProject(account, pname);
            }

            //Количество проектов ДО удаления
            List<ProjectData> initialProjects = api.GetAllProjects(account);
            int initialCount = initialProjects.Count;

            // Удаляем проект
            api.DeleteProject(account, pname);

            // Количество проектов ПОСЛЕ удаления
            List<ProjectData> projectsAfterDeletion = api.GetAllProjects(account);
            int countAfterDeletion = projectsAfterDeletion.Count;

            // Проверка
            if (countAfterDeletion != initialCount - 1)
            {
                throw new Exception("Project count did not decrease as expected.");
            }
            bool projectStillExists = api.IsProjectExist(account, pname);
            if (projectStillExists)
            {
                throw new Exception("Project was not deleted successfully.");
            }
        }
    }
}
