using UrenRegistratie.Framework.DataValidation.Containers;
using UrenRegistratie.Framework.DataValidation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UrenRegistratie.Framework.DataValidation
{
    public static class DataValidator
    {
        public static List<ValidationMessage> Validate(object validateableObject)
        {
            List<ValidationMessage> result = new List<ValidationMessage>();
            if (validateableObject == null)
                return result;

            var pi = validateableObject.GetType().GetRuntimeProperties();

            foreach (var info in pi)
            {
                foreach (object attr in info.GetCustomAttributes(true))
                {
                    if (attr.GetType().GetTypeInfo().ImplementedInterfaces.Where(x=>x.Name=="IValidationAttribute").Count() > 0)
                    {
                        IValidationAttribute val = (IValidationAttribute)attr;
                        if (!val.Validate(info.GetValue(validateableObject, null)))
                        {
                            string message = val.ErrorMessage;
                            try
                            {
                                //PropertyInfo[] lang = typeof(Lang).GetProperties();
                                //if (!string.IsNullOrEmpty(val.ErrorMessage) && val.ErrorMessage.Contains("[") && val.ErrorMessage.Contains("]"))
                                //{
                                //    string search = val.ErrorMessage.Replace('[', ' ').Replace(']', ' ').Trim();
                                //    PropertyInfo langinfo = lang.Where(x => x.Name == search).First();
                                //    message = langinfo.GetValue(Lang.Current, null).ToString();
                                //}
                            }
                            catch { }
                            result.Add(new ValidationMessage { PropertyName = info.Name, Message = message });
                        }
                    }

                }
            }
            return result;
        }

        public static List<ValidationMessage> Validate(object validateableObject, string propertyName)
        {
            List<ValidationMessage> result = new List<ValidationMessage>();
            if (validateableObject == null)
                return result;

            var pi = validateableObject.GetType().GetRuntimeProperties();
            pi = pi.Where(p => p.Name.Equals(propertyName)).ToArray();
            foreach (var info in pi)
            {
                foreach (object attr in info.GetCustomAttributes(true))
                {
                    if (attr.GetType().GetTypeInfo().ImplementedInterfaces.Where(x => x.Name == "IValidationAttribute").Count() > 0)
                    {
                        IValidationAttribute val = (IValidationAttribute)attr;
                        if (!val.Validate(info.GetValue(validateableObject, null)))
                        {
                            string message = val.ErrorMessage;
                            result.Add(new ValidationMessage { PropertyName = info.Name, Message = message });
                        }
                    }
                    //else if (attr.GetType().GetTypeInfo().ImplementedInterfaces.Where(x => x.Name == "IABSBusinessRuleAttribute").Count() > 0)
                    //{
                    //    IBusinessRuleAttribute val = (IBusinessRuleAttribute)attr;
                    //    if (!val.Validate(info.Name, validateableObject))
                    //    {
                    //        string message = val.ErrorMessage;
                    //        result.Add(new ValidationMessage { PropertyName = val.PropertyName, Message = message });
                    //    }
                    //}
                }
            }
            return result;
        }

        public static string GetErrorMessage(object objectToValidate, string propertyName)
        {
            var messages = Validate(objectToValidate, propertyName);

            return string.Join("\r\n", messages.Select(x => x.Message).ToArray());

        }

        public static string GetErrorMessage(object objectToValidate)
        {
            var messages = Validate(objectToValidate);

            return string.Join("\r\n", messages.Select(x => string.Format("{0} {1}", x.PropertyName, x.Message)).ToArray());

        }
    }
}
