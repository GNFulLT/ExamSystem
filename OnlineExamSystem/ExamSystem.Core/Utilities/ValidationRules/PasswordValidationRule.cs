using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Core.Utilities.ValidationRules
{
    public class PasswordValidationRule : IValidationRule
    {
        public int MIN_LENGTH = 5;
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
            string objString = (string)value;

            if (objString.Length < MIN_LENGTH)
            {
                return new ValidationResult(false, $"Minimum password length is {MIN_LENGTH}");
            }
            return ValidationResult.ValidResult;
        }
    }
}
