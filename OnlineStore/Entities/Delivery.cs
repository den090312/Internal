using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Delivery
    {
        public Order Order { get; set; }

        public DateTime Deadline { get; set; }

        public OrderDeliveryMethod DeliveryMethod { get; set; }

        public enum OrderDeliveryMethod
        {
            None = 0,
            Pickup = 1,
            Courier = 2,
            Post = 3
        }
    }
}
