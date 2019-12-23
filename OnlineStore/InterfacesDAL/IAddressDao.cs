using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesDAL
{
    public interface IAddressDao
    {
        void Add(Address address, out Validator validator);
    }
}
