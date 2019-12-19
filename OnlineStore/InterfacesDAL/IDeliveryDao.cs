using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesDAL
{
    public interface IDeliveryDao
    {
        bool Add(Delivery delivery);
    }
}
