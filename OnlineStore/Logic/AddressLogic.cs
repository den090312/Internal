using Entities;
using InterfacesBLL;
using InterfacesDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class AddressLogic
    {
        private readonly IAddressDao addressDao;

        private readonly IValidateLogic<Address> validateLogic;

        public AddressLogic(IAddressDao iAddressDao, IValidateLogic<Address> IValidateLogic)
        {
            addressDao = iAddressDao ?? throw new ArgumentNullException($"{nameof(iAddressDao)} is null!");
            validateLogic = IValidateLogic ?? throw new ArgumentNullException($"{nameof(IValidateLogic)} is null!");
        }
    }
}
