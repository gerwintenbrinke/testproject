using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrenRegistratie.Shared.Entities;

namespace UrenRegistratie.BLL.Handlers
{
    public class EmployeeHandler
    {

        public List<Employee> LstEmployees(Employee filter)
        {

            UrenRegistratie.Data.DAC.Employees employees = new Data.DAC.Employees();
            return employees.List(filter);

        }
    }
}
