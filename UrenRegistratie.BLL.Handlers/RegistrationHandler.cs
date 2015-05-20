using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrenRegistratie.Data.DAC;
using UrenRegistratie.Shared.Entities;

namespace UrenRegistratie.BLL.Handlers
{
    public class RegistrationHandler
    {

        public List<Registration> ListRegistrations()
        {
            Registrations reg = new Registrations();
            return reg.ListRegistrations();

        }

        public void Add(Registration registration)
        {
            Registrations reg = new Registrations();

            if (!string.IsNullOrWhiteSpace(registration.Error))
                throw new Exception(registration.Error);
            if (!ListRegistrations().Contains(registration))
                reg.Add(registration);
        }
    }
}
