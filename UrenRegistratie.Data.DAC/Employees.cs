using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrenRegistratie.Shared.Entities;

namespace UrenRegistratie.Data.DAC
{
    public class Employees
    {

        public List<Employee> List(Employee filter)
        {
            var result = new List<Employee>();

            result.Add(new Employee { Number = "BRI001", Name = "Bri" });
            result.Add(new Employee { Number = "DRI002", Name = "Dri" });
            result.Add(new Employee { Number = "ERI003", Name = "Eri" });
            return result;
        }
    }
}
