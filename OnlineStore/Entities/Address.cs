using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Address
    {
        public string Country { get; set; }

        public string Locality { get; set; }

        public string Street { get; set; }

        public int House { get; set; }

        public int Building { get; set; }

        public int Apartment { get; set; }

        public Validator Validator { get; set; }
    }
}
