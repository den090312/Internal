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

        public AddressLogic(IAddressDao iAddressDao)
        {
            NullCheck(addressDao);

            addressDao = iAddressDao;
        }

        public bool Add(Address address)
        {
            AddressNullCheck(address);
            AddressEmptyStringCheck(address);
            CountryCheck(address.Country);
            NegativeZeroIntCheck(address.House);
            NegativeZeroIntCheck(address.Building);
            NegativeZeroIntCheck(address.Apartment);

            return addressDao.Add(address);
        }

        private void CountryCheck(string country)
        {
            if (!CountryExists(country))
            {
                throw new ArgumentException($"{nameof(country)} is not exists!");
            }
        }

        private bool CountryExists(string country)
        {
            //ToDo проверка существования страны

            return true;
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

        private void NegativeZeroIntCheck(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(value)} is less than zero!");
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
