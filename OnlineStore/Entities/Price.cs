using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Price
    {
        public DateTime Date { get; set; }

        public Currency Currency { get; set; }

        public decimal Value { get; set; }
    }
}
