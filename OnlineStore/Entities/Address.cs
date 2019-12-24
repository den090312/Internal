using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Address
    {
        public string Country { get; set; } = string.Empty;

        public string Region { get; set; } = string.Empty;

        public string Locality { get; set; } = string.Empty;

        public string Street { get; set; } = string.Empty;

        public ushort House { get; set; }

        public ushort Building { get; set; }

        public ushort Apartment { get; set; }
    }
}
