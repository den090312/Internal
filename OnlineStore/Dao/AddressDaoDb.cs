using DTO;
using Entities;
using InterfacesDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dao
{
    public class AddressDaoDb : IAddressDao<Address>
    {
        public void Add(Address address, out ValidatableObject<Address> validatableObject)
        {
            throw new NotImplementedException();
        }
    }
}
