using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesBLL
{
    public interface IValidateLogic
    {
        bool IsValid<T>(IEnumerable<T> validatedObjects, out List<KeyValuePair<string, string>> errors);
    }
}
