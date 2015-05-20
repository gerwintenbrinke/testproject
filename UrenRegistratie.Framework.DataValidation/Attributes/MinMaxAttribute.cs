using UrenRegistratie.Framework.DataValidation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrenRegistratie.Framework.DataValidation.Attributes
{
    [System.AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class MinMaxAttribute : Attribute, IValidationAttribute
    {        
        public MinMaxAttribute(double minValue, double maxValue, string ErrorMessage)
        {
            _minValue = minValue;
            _maxValue = maxValue;
            _errorMessage = ErrorMessage;
        }


        private double _minValue;
        private double _maxValue;

        private string _errorMessage;
        public string ErrorMessage { get { return _errorMessage; } }

        public bool Validate(object Value)
        {
            if (Value == null)
                return true;
            if (Value is decimal || Value is double)
            {
                double val = Convert.ToDouble(Value);
                return val >= _minValue && val <= _maxValue;
            }
            else
            {
                return true;
            }

        }
    }
}

