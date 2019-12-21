using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public byte[] Photo { get; set; }

        public List<Order> ListOrder { get; set; }

        public PaymentCard PaymentCard { get; set; }

        public List<Product> WishList { get; set; }

        public Address Address { get; set; }
    }
}
