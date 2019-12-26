using Entities;
using InterfacesBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class AddressValidateLogic : IValidateLogic<Address>
    {
        private Address address = new Address();

        private readonly Validator validator = new Validator();

        public Validator GetValidator(Address address)
        {
            this.address = address ?? throw new ArgumentNullException(nameof(address));

            ValidateAddress();

            return validator;
        }

        private void ValidateAddress()
        {
            ValidateAddressFields();

            if (validator.Errors.Count() == 0)
            {
                validator.Success = true;
            }
        }

        private void ValidateAddressFields()
        {
            ValidateField("Country", address.Country);
            ValidateField("Region", address.Region);
            ValidateField("Locality", address.Locality);
            ValidateField("Street", address.Street);
            ValidateField("House", address.House);
        }

        private void ValidateField(string name, ushort value)
        {
            if (value == ushort.MinValue)
            {
                validator.Errors.Add((Validator.ErrorType.Warning, name, $"{name} is not specified!"));

                return;
            }

            if (!ValueExists(name, value))
            {
                validator.Errors.Add((Validator.ErrorType.Warning, name, $"{name} is not exists!"));

                return;
            }
        }

        private void ValidateField(string name, string value)
        {
            if (value is null)
            {
                validator.Errors.Add((Validator.ErrorType.Fatal, name, $"{name} is null!"));

                return;
            }

            if (value == string.Empty)
            {
                validator.Errors.Add((Validator.ErrorType.Warning, name, $"{name} is empty!"));

                return;
            }

            if (!ValueExists(name, value))
            {
                validator.Errors.Add((Validator.ErrorType.Warning, name, $"{name} is not exists!"));

                return;
            }
        }

        private bool ValueExists(string name, ushort value)
        {
            switch (name)
            {
                case "House":
                    return HouseExists(value);
                default:
                    return true;
            }
        }

        private bool ValueExists(string name, string value)
        {
            switch (name)
            {
                case "Country":
                    return CountryExists(value);
                case "Region":
                    return RegionExists(value);
                case "Locality":
                    return LocalityExists(value);
                case "Street":
                    return StreetExists(value);
                default:
                    return true;
            }
        }

        private bool HouseExists(ushort value)
        {
            throw new NotImplementedException();
        }

        private bool StreetExists(string value)
        {
            throw new NotImplementedException();
        }

        private bool LocalityExists(string value)
        {
            throw new NotImplementedException();
        }

        private bool RegionExists(string value)
        {
            throw new NotImplementedException();
        }

        private bool CountryExists(string value)
        {
            throw new NotImplementedException();
        }
    }
}
