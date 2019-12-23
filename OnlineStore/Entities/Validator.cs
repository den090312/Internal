using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Validator
    {
        public bool Success { get; set; }

        public IEnumerable<(ErrorType, string, string)> Errors { get; set; }

        public ErrorType Error { get; set; }

        public enum ErrorType
        {
            Fatal,
            Warning
        }
    }
}
