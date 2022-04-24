using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Core.Utilities.ValidationRules
{
    public interface IValidationRule
    {
        public ValidationResult Validate(object value);
    }
}
