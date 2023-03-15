using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Flight
    {
        public int Capacity { get; private set; }
        public Schedule Schedule { get; private set; }
        public List<Order> Orders { get; set; }

        public Flight(int capacity, Schedule schedule)
        {
            Capacity = capacity;
            schedule.IsLoaded = true;
            Schedule = schedule;
            Orders = new List<Order>();
        }
    }
}
