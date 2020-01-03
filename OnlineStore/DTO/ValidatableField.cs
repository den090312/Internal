using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ValidatableField<F>
    {
        public F Field { get; set; }

        public bool IsValid { get; set; }

        public string FieldName { get; }

        public List<Error> Errors { get; set; }

        public bool Continue { get; set; }

        public ValidatableField(F field, string fieldName)
        {
            if (string.IsNullOrEmpty(fieldName)) throw new ArgumentException($"{nameof(fieldName)} must be fullfilled!");

            Field = field;
            IsValid = true;
            Errors = new List<Error>();
            FieldName = fieldName;
            Continue = true;
        }

        public void AddError(Error error)
        {
            if (ErrorIsValid(error))
            {
                IsValid = false;
                Errors.Add(error);
            }
        }

        private static bool ErrorIsValid(Error error)
        {
            if (error is null) throw new ArgumentException(nameof(error) + " is null!");
            if (string.IsNullOrWhiteSpace(error.Method)) throw new ArgumentNullException(nameof(error.Method) + " is null or white space!");
            if (string.IsNullOrWhiteSpace(error.Description)) throw new ArgumentNullException(nameof(error.Description) + " is null or white space!");

            return true;
        }
    }
}
