using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Rating
    {
        public RatingValue Value { get; set; }

        public enum RatingValue
        {
            None = 0,
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }
    }
}
