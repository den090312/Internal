using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Error
    {
        public Types Type { get; set; }

        public string Method { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public enum Types
        {
            None,
            Warning,
            Error,
            Fatal
        }

        public Error(Types type, string method, string description)
        {
            Type = type;
            Method = method;
            Description = description;
        }
    }
}
