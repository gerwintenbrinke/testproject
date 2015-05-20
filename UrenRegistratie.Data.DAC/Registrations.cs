using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrenRegistratie.Shared.Entities;

namespace UrenRegistratie.Data.DAC
{
    public class Registrations
    {
        private UrenRegistratie.Framework.DataCache.Cache dc;
        private const string KEY = "REGISTRATION";
        public Registrations()
        {
            dc = UrenRegistratie.Framework.DataCache.Cache.Current();
        }

        public List<Registration> ListRegistrations()
        {
            Func<List<Registration>> lst = delegate()
            {
                return new List<Registration>();

            };

            return dc.GetData<List<Registration>>(KEY, new TimeSpan(24, 0,0,0,0), lst);

        }
        public void Add(Registration registration)
        {       
           dc.AddData<Registration, List<Registration>>(KEY,registration);
        }
    }
}
