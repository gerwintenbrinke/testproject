using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrenRegistratie.Framework.DataValidation;
using UrenRegistratie.Framework.DataValidation.Attributes;

namespace UrenRegistratie.Shared.Entities
{
    public class Registration : IDataErrorInfo
    {
        public Registration()
        {
            RegistrationDate = DateTime.Today;
        }
        [Required("Verplicht!")]
        public Project Project { get; set; }
        [Required("Verplicht!")]
        public Employee Employee { get; set; }
        [Required("Verplicht!")]
        public DateTime RegistrationDate { get; set; }
        
        [MinMax(0, 24, "Tijd minimaal 0.1 maximaal 24!")]
        public decimal TimeRegistered { get; set; }

        public string Error
        {
            get { return DataValidator.GetErrorMessage(this); }
        }

        public string this[string columnName]
        {
            get { return DataValidator.GetErrorMessage(this, columnName); }
        }
    }
}
