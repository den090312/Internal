using Entities;
using InterfacesBLL;
using InterfacesDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class AddressLogic : IAddressLogic
    {
        private readonly IAddressDao addressDao;

        public bool Add(Address address)
        {
            AddressNullCheck(address);
            AddressEmptyStringCheck(address);

            return addressDao.Add(address);
        }

        private void AddressEmptyStringCheck(Address address)
        {
            EmptyStringCheck(address.Country);
            EmptyStringCheck(address.Locality);
            EmptyStringCheck(address.Street);
            EmptyStringCheck(address.House);
            EmptyStringCheck(address.Building);
            EmptyStringCheck(address.Apartment);
        }

        private void AddressNullCheck(Address address)
        {
            NullCheck(address);
            NullCheck(address.Country);
            NullCheck(address.Locality);
            NullCheck(address.Street);
            NullCheck(address.House);
            NullCheck(address.Building);
            NullCheck(address.Apartment);
        }

        private void EmptyStringCheck(string inputString)
        {
            if (inputString == string.Empty)
            {
                throw new ArgumentException($"{nameof(inputString)} is empty!");
            }
        }

        private void NullCheck<T>(T classObject) where T : class
        {
            if (classObject is null)
            {
                throw new ArgumentNullException($"{nameof(classObject)} is null!");
            }
        }
    }
}
