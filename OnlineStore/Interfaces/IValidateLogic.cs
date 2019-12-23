using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesBLL
{
    public interface IValidateLogic
    {
        Validator GetValidator<T>(T validatedObject) where T: class;
    }
}
