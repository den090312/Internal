using DTO;
using Entities;
using InterfacesBLL;
using Logic.Validate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Logic
{
    public class AddressValidateLogic : IValidateLogic<Address>
    {
        public ValidatableObject<Address> Validate(Address validatedAddress)
        {
            var address = ValidatorExtensions.AsValidatableObject(validatedAddress);

            _ = address.ForField<ValidatableObject<Address>, string>(nameof(validatedAddress.Country)).Required().Length(2, 50);
            _ = address.ForField<ValidatableObject<Address>, string>(nameof(validatedAddress.Region)).Required().Length(2, 50).Match(validatedAddress.Country, Consts.ExpRegion);
            _ = address.ForField<ValidatableObject<Address>, string>(nameof(validatedAddress.Locality)).Required().Length(2, 50).Match(validatedAddress.Locality, Consts.ExpLocality);
            _ = address.ForField<ValidatableObject<Address>, string>(nameof(validatedAddress.Street)).Required().Length(2, 50).Match(validatedAddress.Street, Consts.ExpStreet);

            return address;
        }
    }
}
