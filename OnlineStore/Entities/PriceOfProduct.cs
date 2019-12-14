using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class PriceOfProduct
    {
        public Product Product { get; set; }

        public Price Price { get; set; }

        public DateTime Date { get; set; }
    }
}
