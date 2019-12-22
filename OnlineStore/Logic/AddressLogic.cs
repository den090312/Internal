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

        public string Message { get; private set; } = string.Empty;

        public AddressLogic(IAddressDao iAddressDao)
        {
            addressDao = iAddressDao ?? throw new ArgumentNullException($"{nameof(iAddressDao)} is null!"); ;
        }

        public Tuple<bool, string> Add(Address address) => IsValid(address) ? addressDao.Add(address) : Tuple.Create(false, Message);

        private bool IsValid(Address address) => !AddressHasNoNull(address) 
            || !CountryIsValid(address.Country) 
            || !LocalityIsValid(address.Country, address.Locality) 
            || !StreetIsValid(address.Country, address.Locality, address.Street) 
            || !HouseIsValid(address.Country, address.Locality, address.Street, address.House);

        public bool AddressHasNoNull(Address address) => FieldIsNotNull(address) 
            & FieldIsNotNull(address.Country) 
            & FieldIsNotNull(address.Locality) 
            & FieldIsNotNull(address.Street);

        private bool CountryIsValid(string country) => StringIsNotEmpty(country) & CountryExists(country);

        private bool LocalityIsValid(string country, string locality) => StringIsNotEmpty(locality) & LocalityExists(country, locality);

        private bool StreetIsValid(string country, string locality, string street) => StringIsNotEmpty(street) & StreetExists(country, locality, street);

        private bool HouseIsValid(string country, string locality, string street, int house) => IntIsGreaterThanZero(house)
            & HouseExists(country, locality, street, house);

        private bool HouseExists(string country, string locality, string street, int house)
        {
            //ToDo проверка сушествования дома на улице населенного пункта в стране

            return true;
        }

        private bool StreetExists(string country, string locality, string street)
        {
            //ToDo проверка сушествования улицы в пределах населенного пункта в стране

            return true;
        }

        private bool LocalityExists(string country, string locality)
        {
            //ToDo проверка сушествования населенного пункта в стране

            return true;
        }

        private bool CountryExists(string country)
        {
            //ToDo проверка сушествования страны в списке стран

            return true;
        }

        private bool IntIsGreaterThanZero(int house)
        {
            if (house < 0)
            {
                Message = $"{nameof(house)} is less than zero!";

                return false;
            }
            else
            {
                return true;
            }
        }

        private bool StringIsNotEmpty(string value)
        {
            if (value == string.Empty)
            {
                Message = $"{nameof(value)} is empty!";

                return false;
            }
            else
            {
                return true;
            }
        }

        private bool FieldIsNotNull<T>(T fieldObject) where T : class
        {
            if (fieldObject is null)
            {
                Message = $"{nameof(fieldObject)} is null!";

                return false;
            }
            else 
            {
                return true;
            }
        }
    }
}
