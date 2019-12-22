using InterfacesBLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class ValidateLogic : IValidateLogic
    {
        public bool IsValid<T>(IEnumerable<T> validatedObjects, out List<KeyValuePair<string, string>> errors)
        {
            errors = new List<KeyValuePair<string, string>>();

            if (!IsNull(validatedObjects))
            {
                
            }

            return true;
        }

        private bool IsNull<T>(T classObject) where T : class
        {
            if (classObject is null)
            {
                return true;

                throw new ArgumentNullException($"{nameof(classObject)} is null!");
            }
            else
            {
                return false;
            }
        }
    }
}
