using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Order
    {
        public string Number { get; set; }

        public List<Product> ListProduct { get; set; }

        public decimal Sum { get; set; }

        public DateTime DeadLine { get; set; }

        public int UserId { get; set; }

        public OrderStatus Status { get; set; }

        public OrderDeliveryMethod DeliveryMethod { get; set; }

        public enum OrderStatus
        {
            None = 0,
            Opened = 1,
            PendingForSending = 2,
            PendingForDelivery = 3,
        }

        public enum OrderDeliveryMethod
        {
            None = 0,
            Pickup = 1,
            Courier = 2,
            Post = 3
        }
    }
}
