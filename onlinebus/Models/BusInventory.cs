using System;
using System.Collections.Generic;

namespace onlinebus.Models
{
    public partial class BusInventory
    {
        public int BookingId { get; set; }
        public string BusName { get; set; } = null!;
        public string? BusCategory { get; set; }
        public int AvailabilitySeats { get; set; }
        public string? Boarding { get; set; }
        public string? Departure { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? Price { get; set; }
    }
}
