using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesBLL
{
    public interface IValidateLogic<O>
    {
        ValidatableObject<O> Validate(O validatableObject);
    }
}
