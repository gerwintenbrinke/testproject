using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrenRegistratie.Shared.Entities;

namespace UrenRegistratie.Data.DAC
{
    public class Projects
    {
        public List<Project> List(Project filter)
        {
            var result = new List<Project>();

            result.Add(new Project { Number = "2015050001", Name = "Project O" });
            result.Add(new Project { Number = "2015050002", Name = "Project X" });
            result.Add(new Project { Number = "2015050003", Name = "Project Y" });
            result.Add(new Project { Number = "2015050004", Name = "Project Z" });

            return result;
        }

    }
}
