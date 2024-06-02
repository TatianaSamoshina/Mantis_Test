//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace Mantis_Test
{
    public class ProjectData
    {
        public ProjectData(string projectname)
        {
            this.Projectname = projectname;
        }

        public string Projectname { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            ProjectData other = (ProjectData)obj;
            return Projectname == other.Projectname;
        }

        public override int GetHashCode()
        {
            return Projectname.GetHashCode();
        }
    }
}
