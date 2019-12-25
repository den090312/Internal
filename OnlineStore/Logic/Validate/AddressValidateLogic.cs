using Entities;
using InterfacesBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class AddressValidateLogic: IValidateLogic<Address>
    {
        public Validator GetValidator(Address address)
        {
            var validator = new Validator();

            if (address != null)
            {
                ValidateAddress(address, validator);
            }

            return validator;
        }

        private void ValidateAddress(Address address, Validator validator)
        {
            ValidateAddressFields(address, validator);

            if (address.House == ushort.MinValue)
            {
                validator.Errors.Add((Validator.ErrorType.Warning, "House", $"House isn't specified!"));
            }

            if (validator.Errors.Count() == 0)
            {
                validator.Success = true;
            }
        }

        private void ValidateAddressFields(Address address, Validator validator)
        {
            ValidateField("Country", address.Country, address, validator);
            ValidateField("Region", address.Region, address, validator);
            ValidateField("Locality", address.Locality, address, validator);
            ValidateField("Street", address.Street, address, validator);
            ValidateField("House", address.House, address, validator);
        }

        private void ValidateField(string name, ushort value, Address address, Validator validator)
        {
            if (value == ushort.MinValue)
            {
                validator.Errors.Add((Validator.ErrorType.Warning, name, $"{name} is not specified!"));

                return;
            }

            if (!ValueExists(name, value, address, validator))
            {
                validator.Errors.Add((Validator.ErrorType.Warning, name, $"{name} is not exists!"));

                return;
            }
        }

        private void ValidateField(string name, string value, Address address, Validator validator)
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

            if (!ValueExists(name, value, address, validator))
            {
                validator.Errors.Add((Validator.ErrorType.Warning, name, $"{name} is not exists!"));

                return;
            }
        }

        private bool ValueExists(string name, ushort value, Address address, Validator validator)
        {
            switch (name)
            {
                case "House":
                    return HouseExists(value, address, validator);
                default:
                    return true;
            }
        }

        private bool ValueExists(string name, string value, Address address, Validator validator)
        {
            switch (name)
            {
                case "Country":
                    return CountryExists(value, address, validator);
                case "Region":
                    return RegionExists(value, address, validator);
                case "Locality":
                    return LocalityExists(value, address, validator);
                case "Street":
                    return StreetExists(value, address, validator);
                default:
                    return true;
            }
        }

        private bool HouseExists(ushort value, Address address, Validator validator)
        {
            throw new NotImplementedException();
        }

        private bool StreetExists(string value, Address address, Validator validator)
        {
            throw new NotImplementedException();
        }

        private bool LocalityExists(string value, Address address, Validator validator)
        {
            throw new NotImplementedException();
        }

        private bool RegionExists(string value, Address address, Validator validator)
        {
            throw new NotImplementedException();
        }

        private bool CountryExists(string value, Address address, Validator validator)
        {
            throw new NotImplementedException();
        }
    }
}
