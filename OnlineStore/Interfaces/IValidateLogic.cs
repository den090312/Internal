using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesBLL
{
    public interface IValidateLogic
    {
        bool IsValid<T>(T validatedObject, out List<KeyValuePair<string, string>> errors) where T: class;

        //ToDo сделать сущность Validator вместо кортежа
    }
}
