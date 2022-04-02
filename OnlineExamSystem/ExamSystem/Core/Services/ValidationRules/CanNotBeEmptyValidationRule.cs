using System.Globalization;
using System.Windows.Controls;

namespace ExamSystem.Core.Services.ValidationRules
{
    public class CanNotBeEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
#if DEBUG
            bool flag = false;
                if (value == null)
                {
                flag = true;
                    System.Windows.Forms.MessageBox.Show("EmailValidationRule the object to be validated can not be null or anything but string");
                }
                else if (!(value is string))
                {
                flag = true;
                    System.Windows.Forms.MessageBox.Show("EmailValidationRule the object to be validated can not be null or anything but string");
                }
            if (flag)
            {
                throw new System.Exception("Validation value's can not be null or anything but fixed {type}", new System.Exception("There is a error in CanNotBeEmptyValidationRule"));
            }
#endif

            if ((string)value == string.Empty)
                return new ValidationResult(false, "Can not be empty");
            return ValidationResult.ValidResult;
        }
    }
}
