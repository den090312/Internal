using Entities;
using System.Collections.Generic;

namespace DTO
{
    public class ValidatableObject<O, F>
    {
        public bool IsValid { get; set; }

        public O Obj { get; }

        public List<ValidatableField<F>> Fields { get; set; }

        public ValidatableObject(O obj)
        {
            Obj = obj;
            IsValid = true;
            Fields = new List<ValidatableField<F>>();
        }
    }
}
