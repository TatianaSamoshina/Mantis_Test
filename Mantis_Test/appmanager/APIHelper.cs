using System.Collections.Generic;
using System.Linq;

namespace Mantis_Test
{
    public class APIHelper
    {
        public APIHelper() { }

        public void AddNewProject(AccountData account, ProjectData pname)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();

            if (IsProjectExist(account, pname))
            {
                DeleteProject(account, pname);
            }

            Mantis.ProjectData project = new Mantis.ProjectData();
            project.name = pname.Projectname;
            client.mc_project_add(account.Username, account.Password, project);
        }

        public List<ProjectData> GetAllProjects(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            var projects = client.mc_projects_get_user_accessible(account.Username, account.Password);
            List<ProjectData> result = new List<ProjectData>();
            foreach (var project in projects)
            {
                result.Add(new ProjectData(project.name));
            }
            return result;
        }

        public bool IsProjectExist(AccountData account, ProjectData pname)
        {
            var projects = GetAllProjects(account);
            return projects.Any(p => p.Projectname == pname.Projectname);
        }

        public void DeleteProject(AccountData account, ProjectData pname) // Найти проект по имени и удалить его
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            var projects = client.mc_projects_get_user_accessible(account.Username, account.Password);
           
            foreach (var project in projects)
            {
                if (project.name == pname.Projectname)
                {
                    client.mc_project_delete(account.Username, account.Password, project.id);
                    break;
                }
            }
            projects = client.mc_projects_get_user_accessible(account.Username, account.Password);
        }
    }
}
