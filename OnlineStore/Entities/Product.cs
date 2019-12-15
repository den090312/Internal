using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public byte[] Photo { get; set; }

        public List<Characteristic> ListCharacteristic { get; set; }

        public Price Price { get; set; }

        public List<Feedback> ListFeedback { get; set; }

        public bool Enabled { get; set; }
    }
}
