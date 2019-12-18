﻿using Entities;
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

            PositiveNumberCheck(address.House);
            PositiveNumberCheck(address.Building);
            PositiveNumberCheck(address.Apartment);

            return addressDao.Add(address);
        }

        private void AddressEmptyStringCheck(Address address)
        {
            EmptyStringCheck(address.Country);
            EmptyStringCheck(address.Locality);
            EmptyStringCheck(address.Street);
        }

        private void AddressNullCheck(Address address)
        {
            NullCheck(address);
            NullCheck(address.Country);
            NullCheck(address.Locality);
            NullCheck(address.Street);
        }

        private void PositiveNumberCheck(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentException($"{nameof(number)} is less than zero!");
            }
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