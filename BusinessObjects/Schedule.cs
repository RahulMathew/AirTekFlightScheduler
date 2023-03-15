using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Schedule
    {
        public int FlightNumber { get; set; }
        public string? Departure { get; set; }
        public string? Arrival { get; set; }
        public int Day { get; set; }
        public bool IsLoaded { get; set; }
    }
}
