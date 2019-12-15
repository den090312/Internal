using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Feedback
    {
        public User User { get; set; }

        public DateTime DateTime { get; set; }

        public string Text { get; set; }

        public Rating Rating { get; set; }

        public List<Feedback> ListFeedback { get; set; }
    }
}
