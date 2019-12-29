using Dao;
using Entities;
using InterfacesBLL;
using InterfacesDAL;
using Logic;

namespace DependencyResolver
{
    public class Dependencies
    {
        private static readonly IAddressDao<Address> addressDao;

        private static readonly IValidateLogic<Address> addressValidateLogic;

        public static IAddressLogic AddressLogic { get; private set; }

        static Dependencies()
        {
            addressDao = new AddressDaoDb();
            addressValidateLogic = new AddressValidateLogic();
            AddressLogic = new AddressLogic(addressDao, addressValidateLogic);
        }
    }
}
