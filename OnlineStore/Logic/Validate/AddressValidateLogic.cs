using DTO;
using Entities;
using InterfacesBLL;
using Logic.Validate;
using System;
using static Logic.Validate.ValidatorExtensions;

namespace Logic
{
    public class AddressValidateLogic : IValidateLogic<Address>
    {
        public ValidatableObject<Address> Validate(Address validatedAddress)
        {
            var address = ValidatorExtensions.AsValidatableObject(validatedAddress);

            _ = address.ForField<ValidatableObject<Address>, string>(nameof(validatedAddress.Country)).Required().Length(2, 50);
            _ = address.ForField<ValidatableObject<Address>, string>(nameof(validatedAddress.Region)).Required().Length(2, 50).Match(Consts.ExpRegion);
            _ = address.ForField<ValidatableObject<Address>, string>(nameof(validatedAddress.Locality)).Required().Length(2, 50).Match(Consts.ExpLocality);
            _ = address.ForField<ValidatableObject<Address>, string>(nameof(validatedAddress.Street)).Required().Length(2, 50).Match(Consts.ExpStreet);

            _ = address.ForField<ValidatableObject<Address>, ushort>(nameof(validatedAddress.House)).Custom(HouseIsTen(validatedAddress));

            return address;
        }

        private CustomValidator<ushort> HouseIsTen(Address validatedAddress)
        {
            throw new NotImplementedException();
        }
    }
}
