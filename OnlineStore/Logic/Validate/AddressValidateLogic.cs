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

            _ = add.ForField<ValidatableObject<Address>, ushort>(nameof(address.House)).Custom(CheckHouseForTen);

            return add;
        }

        private void CheckHouseForTen(ref ValidatableField<ushort> field)
        {
            if (field.Field != 10)
            {
                field.AddError(new Error(Error.Types.Warning, field.FieldName, $"{nameof(field.FieldName)} is not equal to 10"));
            }
        }
    }
}
