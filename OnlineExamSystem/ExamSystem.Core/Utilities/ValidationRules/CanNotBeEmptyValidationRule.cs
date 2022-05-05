using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Core.Utilities.ValidationRules
{
    public class CanNotBeEmptyValidationRule : IValidationRule
    {
        public ValidationResult Validate(object value)
        {
            if (value == null)
                value = string.Empty;
#if DEBUG
            bool flag = false;
            if (value == null)
            {
                flag = true;
                throw new Exception("EmailValidationRule the object to be validated can not be null or anything but string");
            }
            else if (!(value is string))
            {
                flag = true;
                throw new Exception("EmailValidationRule the object to be validated can not be null or anything but string");
            }
           
#endif

            if ((string)value == string.Empty)
                return new ValidationResult(false, "Can not be empty");
            return ValidationResult.ValidResult;
        }
    }
}
