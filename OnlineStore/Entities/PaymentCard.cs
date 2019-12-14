using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class PaymentCard
    {
        public string Number { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public sbyte ExpirationMonth { get; set; }

        public sbyte ExpirationYear { get; set; }

        public sbyte VerificationValue { get; set; }
    }
}
