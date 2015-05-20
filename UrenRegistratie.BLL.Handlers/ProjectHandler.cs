using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrenRegistratie.Data.DAC;
using UrenRegistratie.Shared.Entities;

namespace UrenRegistratie.BLL.Handlers
{
    public class ProjectHandler
    {

        public List<Project> LstProjects(Project filter)
        {
            Projects p = new Projects();
            return p.List(filter);
        }
    }
}
