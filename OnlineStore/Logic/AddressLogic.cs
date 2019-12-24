using Entities;
using InterfacesBLL;
using InterfacesDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class AddressLogic : IAddressLogic
    {
        private readonly IAddressDao addressDao;

        private readonly IValidateLogic validateLogic;

        public AddressLogic(IAddressDao iAddressDao, IValidateLogic IValidateLogic)
        {
            addressDao = iAddressDao ?? throw new ArgumentNullException($"{nameof(iAddressDao)} is null!");
            validateLogic = IValidateLogic ?? throw new ArgumentNullException($"{nameof(IValidateLogic)} is null!");
        }

        public void Add(Address address, out Validator validator)
        {
            if (address != null)
            {
                AddAddress(address, out validator);
            }
            else
            {
                validator = new Validator();
                var nameOfAddress = nameof(address);
                validator.Errors.Add((Validator.ErrorType.Fatal, nameOfAddress, $"{nameOfAddress} is null!"));
            }
        }

        private void AddAddress(Address address, out Validator validator)
        {
            validator = validateLogic.GetValidator(address);

            if (validator.Success)
            {
                addressDao.Add(address, out Validator daoValidator);
                validator = daoValidator;
            }
        }
    }
}
