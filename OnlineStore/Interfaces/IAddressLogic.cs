using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesBLL
{
    public interface IAddressLogic
    {
        void Add(Address address, out ValidatableObject validator);
    }
}
