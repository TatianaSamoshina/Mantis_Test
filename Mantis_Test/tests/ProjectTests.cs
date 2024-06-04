using System;
using System.Collections.Generic;
//using System.Threading;
using NUnit.Framework;

namespace Mantis_Test
{
    [TestFixture]
    public class ProjectTests : TestBase
    {

        [Test]

        public void DeleteProjectTest()
        {
            string projectNameToDelete = "t2";
            projectHelper.GoToPageProject();
            projectHelper.PrintAllProjectLinks();
            
            // Найти индекс проекта, если проекта нет - создать
            int projectIndex = projectHelper.FindProjectIndex(projectNameToDelete);
            if (projectIndex == -1)
            {
                projectHelper.AddProject(projectNameToDelete);
                projectIndex = projectHelper.FindProjectIndex(projectNameToDelete);
            }

            // Открыть проект по индексу
            projectHelper.GoToProjectByIndex(projectIndex);
            //Удалить проект
            projectHelper.Delete();
            //Проверка
            projectIndex = projectHelper.FindProjectIndex(projectNameToDelete);
            if (projectIndex != -1)
            {
                Assert.Fail("Project 't2' not delete.");
            }           
        }


        [Test]
        public void AddProjectTest()
        {
            projectHelper.GoToPageProject();
            projectHelper.PrintAllProjectLinks();
            string projectNameToAdd = "t2";
            int projectIndexAdd = projectHelper.FindProjectIndex(projectNameToAdd);

            // Если такой проект уже есть - удалить
            if (projectIndexAdd != -1)
            {
                projectHelper.DeleteProject(projectNameToAdd);               
            }
            //Добавить проект
            projectHelper.AddProject(projectNameToAdd);
            //Проверка через индекс по названию проекта
            projectIndexAdd = projectHelper.FindProjectIndex(projectNameToAdd);                      
            if (projectIndexAdd == -1)
            {
                Assert.Fail("Project 't2' not add.");
            }
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
