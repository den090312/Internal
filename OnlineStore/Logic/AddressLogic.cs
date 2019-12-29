using DTO;
using Entities;
using InterfacesBLL;
using InterfacesDAL;
using System;

namespace Logic
{
    public class AddressLogic : IAddressLogic
    {
        private readonly IAddressDao<Address> addressDao;

        private readonly IValidateLogic<Address> validateLogic;

        public AddressLogic(IAddressDao<Address> iAddressDao, IValidateLogic<Address> IValidateLogic)
        {
            addressDao = iAddressDao ?? throw new ArgumentNullException($"{nameof(iAddressDao)} is null!");
            validateLogic = IValidateLogic ?? throw new ArgumentNullException($"{nameof(IValidateLogic)} is null!");
        }

        public void Add(Address address)
        {
            if (validateLogic.Validate(address ?? throw new ArgumentNullException($"{nameof(address)} is null!")).IsValid)
            {
                addressDao.Add(address, out ValidatableObject<Address> validatedAddress);
            }
        }
    }
}
