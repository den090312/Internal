using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesDAL
{
    public interface IPaymentCardDao
    {
        bool Add(PaymentCard paymentCard);
    }
}
