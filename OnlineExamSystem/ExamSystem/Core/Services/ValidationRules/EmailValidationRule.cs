using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ExamSystem.Core.Services.ValidationRules
{
    public class EmailValidationRule : ValidationRule
    {
        private Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
#if DEBUG
            bool flag = false;
            if(value == null)
            {
                flag = true;
            System.Windows.Forms.MessageBox.Show("EmailValidationRule the object to be validated can not be null or anything but string");
            }
            else if(!(value is string))
            {
                flag = true;
             System.Windows.Forms.MessageBox.Show("EmailValidationRule the object to be validated can not be null or anything but string");
            }
            if (flag)
            {
                throw new System.Exception("Validation value's can not be null or anything but fixed {type}",
                    new System.Exception("There is a error in EmailValidationRule"));
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
