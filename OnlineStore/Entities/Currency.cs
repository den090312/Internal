using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Currency
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public short DigitalCode { get; set; }

        public string LetterCode { get; set; }

        public sbyte Multiplicity { get; set; }
    }
}
