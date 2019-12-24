using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Validator
    {
        public bool Success { get; set; }

        public List<(ErrorType, string, string)> Errors { get; set; } = new List<(ErrorType, string, string)>();

        public ErrorType Error { get; set; } = ErrorType.None;

        public enum ErrorType
        {
            None,
            Fatal,
            Warning
        }
    }
}
