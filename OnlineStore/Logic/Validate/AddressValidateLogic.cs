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
        public ValidatableObject<Address> Validate(Address address)
        {
            var add = ValidatorExtensions.AsValidatableObject(address);

            _ = add.ForField<ValidatableObject<Address>, string>(nameof(address.Country)).Required().Length(2, 50);
            _ = add.ForField<ValidatableObject<Address>, string>(nameof(address.Region)).Required().Length(2, 50).Match(Consts.ExpRegion);
            _ = add.ForField<ValidatableObject<Address>, string>(nameof(address.Locality)).Required().Length(2, 50).Match(Consts.ExpLocality);
            _ = add.ForField<ValidatableObject<Address>, string>(nameof(address.Street)).Required().Length(2, 50).Match(Consts.ExpStreet);
            _ = add.ForField<ValidatableObject<Address>, ushort>(nameof(address.House)).Custom(HouseIsTen(address));

            return add;
        }

        private Error HouseIsTen(Address address)
        {
            if (address.House == 10)
            {
                return null;
            }
            else
            {
                return new Error(Error.Types.Warning, nameof(HouseIsTen), $"{nameof(address.House)} is not equal to 10");
            }
        }
    }
}
