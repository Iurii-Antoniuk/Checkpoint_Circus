using System;
using System.Collections.Generic;
using System.Text;

namespace Database_Api
{
    public class Feedback
    {
        public int FeedbackId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
    }
}
