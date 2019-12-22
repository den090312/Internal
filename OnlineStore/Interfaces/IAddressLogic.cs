using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesBLL
{
    public interface IAddressLogic
    {
        Tuple<bool, string> Add(Address address);
    }
}
