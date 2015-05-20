using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrenRegistratie.Framework.DataValidation.Interfaces
{
    public interface IValidationAttribute
    {
        string ErrorMessage { get; }
        bool Validate(object Value);
    }
}
