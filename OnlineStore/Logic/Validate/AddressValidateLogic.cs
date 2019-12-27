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

            _ = address.Country.NotNull().Required(address.Country).Length(address.Country, 2, 50).Match(address.Country).Exists(address.Country);
            _ = address.Region.NotNull().Required(address.Region).Length(address.Region, 2, 50).Match(address.Region).Exists(address.Region);
            _ = address.Locality.NotNull().Required(address.Locality).Length(address.Locality, 2, 50).Match(address.Locality).Exists(address.Locality);
            _ = address.Street.NotNull().Required(address.Street).Length(address.Street, 2, 50).Match(address.Street).Exists(address.Street);
            _ = address.House.Required().Exists(address.House);

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
        private readonly static string expression = @"[А-Я]+(([а-я]+)\s*)*";

        public static Validator Validator { get; private set; } = new Validator();

        public static bool NotNull(this string field)
        {
            if (field is null)
            {
                Validator.Errors.Add((Validator.ErrorType.Fatal, nameof(field), $"{nameof(field)} is null!"));

                return false;
            }

            return true;
        }

        public static bool Required(this bool notNull, string field)
        {
            if (!notNull)
            {
                return false;
            }

            var name = nameof(field);

            return name == "Country" || name == "Region" || name == "Locality" || name == "Street";
        }

        public static bool Required(this ushort field)
        {
            return nameof(field) == "House";
        }

        public static bool Length(this bool required, string field, ushort begin, ushort end)
        {
            if (!required)
            {
                return false;
            }

            if (field.Length < begin | field.Length > end)
            {
                Validator.Errors.Add((Validator.ErrorType.Warning, nameof(field), $"{nameof(field)} has incorrect length!"));

                return false;
            }

            return true;
        }

        public static bool Match(this bool lengthIsOk, string field)
        {
            if (!lengthIsOk)
            {
                return false;
            }

            var isMatch = new Regex(expression).IsMatch(field);

            if (!isMatch)
            {
                Validator.Errors.Add((Validator.ErrorType.Warning, nameof(field), $"{nameof(field)} is empty!"));
            }

            return isMatch;
        }

        public static bool Exists(this bool match, string field)
        {
            return true;
        }

        public static bool Exists(this bool match, ushort field)
        {
            return true;
        }
    }
}
