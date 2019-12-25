﻿using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesBLL
{
    public interface IValidateLogic<T>
    {
        Validator GetValidator(T validatedObject);
    }
}
