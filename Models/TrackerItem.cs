using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.Models
{
    public class TrackerItem
    {
        public int Id { get; set; }
        public double Weight { get; set; }
        public double GoalWeight { get; set; }
        public String Name { get; set; }
        public DateTime Date { get; set; }
    }
}
