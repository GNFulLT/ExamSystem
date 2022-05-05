using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ExamSystem.Core.Utilities.ValidationRules
{
    public class EmailValidationRule : IValidationRule
    {
        private Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        public ValidationResult Validate(object value)
        {
            if (value == null)
                value = string.Empty;
#if DEBUG
            bool flag = false;

            if (!(value is string))
            {
                flag = true;
                throw new Exception("EmailValidationRule the object to be validated can not be null or anything but string");
            }


#endif

            if (emailRegex.IsMatch((string)value))
            {
                return ValidationResult.ValidResult;
            }
            else
            {
                return new ValidationResult(false, "Email is not valid");
            }
        }
    }
}
