using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_02_EFC_.Models
{
    public class OrganizerProfile
    {
        public int Id { get; set; }
        public string? Biography { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? LogoUrl { get; set; }
        public int OrganizerId { get; set; }

        public Organizer Organizer { get; set; } = null!;
    }
}
