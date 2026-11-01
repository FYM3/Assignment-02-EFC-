using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_02_EFC_.Models
{
    public class Badge
    {
        public int Id { get; set; }

        public string BadgeNumber { get; set; } = null!;
        public DateTime IssueDate { get; set; }
        public BadgeTier Tier { get; set; }

        public int AttendeeId { get; set; }
        public Attendee Attendee { get; set; } = null!;
    } 
}
