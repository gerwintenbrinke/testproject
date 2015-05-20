using UrenRegistratie.Framework.DataValidation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrenRegistratie.Framework.DataValidation.Attributes
{
    [System.AttributeUsage(AttributeTargets.Property,AllowMultiple=false,Inherited=true)]
    public class RequiredAttribute : Attribute, IValidationAttribute
    {        
        public RequiredAttribute(string ErrorMessage)
        {
            _required = true;
            _errorMessage = ErrorMessage;
        }

        private bool _required;

        private string _errorMessage;
        public string ErrorMessage { get { return _errorMessage; } }
        

        public bool Validate(object Value)
        {
            return RequiredValueMet(Value);
        }

        private bool RequiredValueMet(object value)
        {
            if (value == null)
                return false;

            if (value.GetType() == typeof(string))
                return RequiredValueMet(value.ToString());
            else
                return true;

        }

        private bool RequiredValueMet(string value)
        {
            return !string.IsNullOrEmpty(value);
        }
    }
}
