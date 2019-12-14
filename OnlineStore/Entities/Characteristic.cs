using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Characteristic
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Value { get; set; }

        public UnitOfMeasurement UnitOfMeasurement { get; set; }
    }
}
