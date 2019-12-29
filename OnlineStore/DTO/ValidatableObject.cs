using Entities;
using System.Collections.Generic;

namespace DTO
{
    public class ValidatableObject<O>
    {
        public O Obj { get; }

        public bool IsValid { get; set; }

        public List<(string fieldName, List<Error> fieldErrors)> Errors { get; set; }

        public ValidatableObject(O obj)
        {
            Obj = obj;
            Errors = new List<(string fieldName, List<Error> fieldErrors)>();
        }
    }
}
