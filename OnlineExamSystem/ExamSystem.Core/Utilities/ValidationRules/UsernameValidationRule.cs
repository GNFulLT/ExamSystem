using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ExamSystem.Core.Utilities.ValidationRules
{
    public class UsernameValidationRule : IValidationRule
    {
        Regex usernameRegex = new Regex("^[a-zA-Z0-9]+$");

        public ValidationResult Validate(object value)
        {
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
            if (flag)
            {
                throw new System.Exception("Validation value's can not be null or anything but fixed {type}",
                    new System.Exception("There is a error in EmailValidationRule"));
            }

#endif
            if ((value as string) is " ")
            {
                return new ValidationResult(false, "Username shouldn't contain space");
            }
            if (!usernameRegex.IsMatch((value as string)))
            {
                return new ValidationResult(false, "Username should only contain english characters");
            }
            return ValidationResult.ValidResult;
        }
    }
}
