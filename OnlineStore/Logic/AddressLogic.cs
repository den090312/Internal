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

        public Tuple<bool, List<KeyValuePair<string, string>>> Add(Address address)
        {
            if (validateLogic.IsValid(address, out List<KeyValuePair<string, string>> errors))
            {
                return addressDao.Add(address);
            }
            else
            {
                return Tuple.Create(false, errors);
            }
        }
    }
}
