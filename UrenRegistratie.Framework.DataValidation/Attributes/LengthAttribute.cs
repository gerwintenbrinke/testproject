using UrenRegistratie.Framework.DataValidation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrenRegistratie.Framework.DataValidation.Attributes
{
    [System.AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class LengthAttribute : Attribute, IValidationAttribute
    {
        private bool _fixLength;
        public LengthAttribute(int Length, string ErrorMessage)
        {
            _length = Length;
            _fixLength = true;
            _errorMessage = ErrorMessage;
        }

        public LengthAttribute(int MinLength, int MaxLength, string ErrorMessage)
        {
            _minLength = MinLength;
            _maxLength = MaxLength;
            _fixLength = false;
            _errorMessage = ErrorMessage;
        }

        private int _length;
        private int _minLength;
        private int _maxLength;

        private string _errorMessage;
        public string ErrorMessage { get { return _errorMessage; } }

        public bool Validate(object Value)
        {
            if (Value == null && ((_fixLength && _length > 0) || _minLength > 0))
                return false;

            if (Value == null && !_fixLength && _minLength == 0)
                return true;

            string data = Value.ToString();

            if (_fixLength)
                return data.Length == _length;
            else
                return data.Length >= _minLength && data.Length <= _maxLength;

        }
    }
}

