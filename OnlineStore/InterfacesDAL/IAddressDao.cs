using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesDAL
{
    public interface IAddressDao<O>
    {
        void Add(O address, out ValidatableObject<O> validatableObject);
    }
}
