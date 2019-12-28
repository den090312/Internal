using Entities;
using System.Collections.Generic;

namespace DTO
{
    public class ValidatableObject<O>
    {
        public bool IsValid { get; set; }

        public O Obj { get; }

        public List<(string fieldName, List<Error> Errors)> ListError { get; set; }

        public ValidatableObject(O obj)
        {
            Obj = obj;
            IsValid = true;
            ListError = new List<(string fieldName, List<Error> Errors)>();
        }
    }
}
