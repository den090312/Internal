using DTO;
using Entities;
using InterfacesBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Logic
{
    public class AddressValidateLogic : IValidateLogic<Address>
    {
        public ValidatableObject<Address> Validate(Address address)
        {
            var validatedAddress = new ValidatableObject<Address>(address);



            return validatedAddress;
        }
    }
}
