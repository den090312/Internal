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

        public int UserId { get; set; }

        public OrderStatus Status { get; set; }

        public enum OrderStatus
        {
            None = 0,
            Opened = 1,
            PendingForSending = 2,
            PendingForDelivery = 3,
        }
    }
}
