using Entities;
using InterfacesBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Logic
{
    public class AddressValidateLogic : IValidateLogic<Address>
    {
        public Validator GetValidator(Address inputAddress)
        {
            var address = inputAddress ?? throw new ArgumentNullException(nameof(inputAddress));

            AddressValidation.StringFieldName = "Country";
            AddressValidation.StringFieldValue = address.Country;
            _ = address.Country.NotNull().Required().Length(2, 50).Match().Exists();

            AddressValidation.StringFieldName = "Region";
            AddressValidation.StringFieldValue = address.Region;
            _ = address.Region.NotNull().Required().Length(2, 50).Match().Exists();

            AddressValidation.StringFieldName = "Locality";
            AddressValidation.StringFieldValue = address.Locality;
            _ = address.Locality.NotNull().Required().Length(2, 50).Match().Exists();

            AddressValidation.StringFieldName = "Street";
            AddressValidation.StringFieldValue = address.Street;
            _ = address.Street.NotNull().Required().Length(2, 50).Match().Exists();

            AddressValidation.StringFieldName = "House";
            AddressValidation.UshortField = address.House;
            _ = address.House.Required().Exists();

            var validator = AddressValidation.Validator;

            if (validator.Errors.Count() == 0)
            {
                validator.Success = true;
            }

            return validator;
        }
    }

    public static class AddressValidation
    {
        private readonly static string expression; 

        public static Validator Validator { get; private set; }

        public static string StringFieldName { get; set; }

        public static string StringFieldValue { get; set; }

        public static ushort UshortField { get; set; }

        static AddressValidation()
        {
            expression = @"[А-Я]+(([а-я]+)\s*)*";
            Validator = new Validator();
            StringFieldName = string.Empty;
            StringFieldValue = string.Empty;
        }

        public static bool NotNull(this string field)
        {
            if (field is null)
            {
                Validator.Errors.Add((Validator.ErrorType.Fatal, nameof(field), $"{nameof(field)} is null!"));

                return false;
            }

            return true;
        }

        public static bool Required(this bool notNull)
        {
            if (!notNull)
            {
                return false;
            }

            var name = nameof(StringFieldName);

            return name == "Country" || name == "Region" || name == "Locality" || name == "Street";
        }

        public static bool Required(this ushort field)
        {
            return nameof(field) == "House";
        }

        public static bool Length(this bool required, ushort begin, ushort end)
        {
            if (!required)
            {
                return false;
            }

            if (StringFieldValue.Length < begin | StringFieldValue.Length > end)
            {
                Validator.Errors.Add((Validator.ErrorType.Warning, nameof(StringFieldName), $"{nameof(StringFieldName)} has incorrect length!"));

                return false;
            }

            return true;
        }

        public static bool Match(this bool lengthIsOk)
        {
            if (!lengthIsOk)
            {
                return false;
            }

            var isMatch = new Regex(expression).IsMatch(StringFieldValue);

            if (!isMatch)
            {
                Validator.Errors.Add((Validator.ErrorType.Warning, nameof(StringFieldName), $"{nameof(StringFieldName)} is empty!"));
            }

            return isMatch;
        }

        public static bool Exists(this bool match)
        {
            return true;
        }
    }
}
