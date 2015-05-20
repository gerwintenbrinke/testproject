using UrenRegistratie.Framework.DataValidation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UrenRegistratie.Framework.DataValidation.Attributes
{
        [System.AttributeUsage(AttributeTargets.Property,AllowMultiple=false,Inherited=true)]
    public  class RegExAttribute : Attribute, IValidationAttribute
    {
        public RegExAttribute(string RegularExpression, string ErrorMessage)
        {
            _errorMessage = ErrorMessage;
            _regularExpression = RegularExpression;
        }

        private string _errorMessage;
        public string ErrorMessage { get { return _errorMessage; } }

        private string _regularExpression;
        
        public bool Validate(object Value)
        {
            if (Value == null)
                return false;

            Regex regex = new Regex(_regularExpression);

            return regex.IsMatch(Value.ToString());
        }
    }
}
