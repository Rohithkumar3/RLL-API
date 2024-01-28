using System;
using System.Collections.Generic;

namespace onlinebus.Models
{
    public partial class Usersignup
    {
        public string? FullName { get; set; }
        public string? Dob { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string? Pincode { get; set; }
        public string? Address { get; set; }
        public string Username { get; set; } = null!;
        public string? Password { get; set; }
    }
}
