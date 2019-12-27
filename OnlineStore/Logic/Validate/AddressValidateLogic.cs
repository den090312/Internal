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

            _ = address.Country.As(nameof(address.Country)).Required().NotNull().Length(2, 50).Match();
            _ = address.Region.As(nameof(address.Region)).Required().NotNull().Length(2, 50).Match();
            _ = address.Locality.As(nameof(address.Locality)).Required().NotNull().Length(2, 50).Match();
            _ = address.Street.As(nameof(address.Street)).Required().NotNull().Length(2, 50).Match();
            _ = address.House.As(nameof(address.House)).Required();

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

        public static string FieldName { get; set; }

        public static string StringFieldValue { get; set; }

        static AddressValidation()
        {
            expression = @"[А-Я]+(([а-я]+)\s*)*";
            Validator = new Validator();
            FieldName = string.Empty;
            StringFieldValue = string.Empty;
        }

        public static string As(this string value, string name)
        {
            FieldName = name;
            StringFieldValue = value;

            return value;
        }

        public static ushort As(this ushort value, string name)
        {
            FieldName = name;

            return value;
        }

        public static bool NotNull(this bool continew)
        {
            if (!continew)
            {
                return false;
            }

            if (StringFieldValue is null)
            {
                Validator.Errors.Add((Validator.ErrorType.Fatal, FieldName, $"{FieldName} is null!"));

                return false;
            }

            return true; 
        }

        public static bool Required(this string field)
        {
            return FieldName == "Country" || FieldName == "Region" || FieldName == "Locality" || FieldName == "Street";
        }

        public static bool Required(this ushort field)
        {
            return FieldName == "House";
        }

        public static bool Length(this bool continew, ushort begin, ushort end)
        {
            if (!continew)
            {
                return false;
            }

            if (StringFieldValue.Length < begin | StringFieldValue.Length > end)
            {
                Validator.Errors.Add((Validator.ErrorType.Warning, FieldName, $"{FieldName} has incorrect length!"));

                return false;
            }

            return true;
        }

        public static bool Match(this bool continew)
        {
            if (!continew)
            {
                return false;
            }

            if (!new Regex(expression).IsMatch(StringFieldValue))
            {
                Validator.Errors.Add((Validator.ErrorType.Warning, FieldName, $"{FieldName} is not match to expression!"));
            }

            return true;
        }
    }
}
