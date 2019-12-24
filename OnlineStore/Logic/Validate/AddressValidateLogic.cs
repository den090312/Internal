using Entities;
using InterfacesBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class AddressValidateLogic : IValidateLogic
    {
        public Validator GetValidator<T>(T validatedObject) where T: class
        {
            var validator = new Validator();

            if (ObjectIsAddress(validatedObject, validator, out Address address))
            {
                ValidateAddress(address, validator);
            }

            return validator;
        }

        private bool ObjectIsAddress<T>(T validatedObject, Validator validator, out Address address) where T : class
        {
            var nameOfObject = nameof(validatedObject);

            if (validatedObject == null)
            {
                validator.Errors.Add((Validator.ErrorType.Fatal, nameOfObject, $"{nameOfObject} is null!"));
                address = null;

                return false;
            }

            if (!(validatedObject is Address))
            {
                validator.Errors.Add((Validator.ErrorType.Fatal, nameOfObject, $"{nameOfObject} isn't address!"));
                address = null;

                return false;
            }

            address = validatedObject as Address;

            return true;
        }

        private void ValidateAddress(Address address, Validator validator)
        {
            if (!CountryExists(address, validator) 
                || !RegionExists(address, validator) 
                || !LocalityExists(address, validator) 
                || !StreetExists(address, validator))
            {
                return;
            }

            if (address.House == ushort.MinValue)
            {
                validator.Errors.Add((Validator.ErrorType.Warning, "House", $"House isn't specified!"));
            }

            if (validator.Errors.Count() == 0)
            {
                validator.Success = true;
            }
        }

        private bool StreetExists(Address address, Validator validator)
        {
            var street = address.Street;

            if (street == string.Empty)
            {
                validator.Errors.Add((Validator.ErrorType.Warning, "Street", "Street isn't specified!"));

                return false;
            }

            var country = address.Country;
            var region = address.Region;
            var locality = address.Locality;

            if (!StreetExists(country, region, locality, street))
            {
                validator.Errors.Add((Validator.ErrorType.Warning, "Street", $"Street: '{street}' isn't exists " +
                    $"in locality: '{locality}', " +
                    $"in region: '{region}', " +
                    $"in country: '{country}'!"));

                return false;
            }

            return true;
        }

        private bool LocalityExists(Address address, Validator validator)
        {
            var locality = address.Locality;

            if (locality == string.Empty)
            {
                validator.Errors.Add((Validator.ErrorType.Warning, "Locality", "Locality isn't specified!"));

                return false;
            }

            var country = address.Country;
            var region = address.Region;

            if (!LocalityExists(country, region, locality))
            {
                validator.Errors.Add((Validator.ErrorType.Warning, "Locality", $"Locality: '{locality}' isn't exists " +
                    $"in region: '{region}', " +
                    $"in country: '{country}'!"));

                return false;
            }

            return true;
        }

        private bool RegionExists(Address address, Validator validator)
        {
            var region = address.Region;

            if (region == string.Empty)
            {
                validator.Errors.Add((Validator.ErrorType.Warning, "Region", "Region isn't specified!"));

                return false;
            }

            var country = address.Country;

            if (!RegionExists(country, region))
            {
                validator.Errors.Add((Validator.ErrorType.Warning, "Region", $"Region: '{region}' isn't exists " +
                    $"in country: '{country}'!"));

                return false;
            }

            return true;
        }

        private bool CountryExists(Address address, Validator validator)
        {
            var country = address.Country;

            if (country == string.Empty)
            {
                validator.Errors.Add((Validator.ErrorType.Warning, "Country", "Country isn't specified!"));

                return false;
            }

            if (!CountryExists(country))
            {
                validator.Errors.Add((Validator.ErrorType.Warning, "Country", $"Country: '{country}' isn't exists!"));

                return false;
            }

            return true;
        }

        private bool StreetExists(string country, string region, string locality, string street)
        {
            //ToDo проверка существования улицы 

            return true;
        }

        private bool LocalityExists(string country, string region, string locality)
        {
            //ToDo проверка существования населенного пункта

            return true;
        }

        private bool RegionExists(string country, string locality)
        {
            //ToDo проверка существования региона

            return true;
        }

        private bool CountryExists(string country)
        {
            //ToDo проверка существования страны в списке стран

            return true;
        }
    }
}
