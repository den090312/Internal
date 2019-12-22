using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Validator
    {
        public bool Success { get; set; }

        public IEnumerable<object> ValidateObjects { get; set; }

        public KeyValuePair<string, string> Errors { get; set; } 
    }
}
