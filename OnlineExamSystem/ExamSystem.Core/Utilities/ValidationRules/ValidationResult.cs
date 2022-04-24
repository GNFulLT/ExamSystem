using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Core.Utilities.ValidationRules
{
    public class ValidationResult
    {
        public bool IsValid { get; }
        public object ErrorContent { get; }

        public ValidationResult(bool isValid, object errorContent)
        {
            IsValid = isValid;
            ErrorContent = errorContent;
        }

        public static ValidationResult ValidResult => new ValidationResult(true,"");


        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(ValidationResult left, ValidationResult right)
        {
            return left.IsValid == right.IsValid;
        }
        public static bool operator !=(ValidationResult left, ValidationResult right)
        {
            return left.IsValid == right.IsValid;
        }
    }
}
