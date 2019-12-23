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
            var daoValidator = new Validator();

            if (validateLogic.GetValidator(address).Success)
            {
                addressDao.Add(address, out daoValidator);
            }

            validator = daoValidator;
        }
    }
}
