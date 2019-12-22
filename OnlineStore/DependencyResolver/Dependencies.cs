using Dao;
using InterfacesBLL;
using InterfacesDAL;
using Logic;

namespace DependencyResolver
{
    public class Dependencies
    {
        private static readonly IAddressDao addressDao;

        private static readonly IValidateLogic addressValidateLogic;

        public static IAddressLogic AddressLogic { get; private set; }

        static Dependencies()
        {
            addressDao = new AddressDaoDb();
            addressValidateLogic = new AddressValidateLogic();
            AddressLogic = new AddressLogic(addressDao, addressValidateLogic);
        }
    }
}
