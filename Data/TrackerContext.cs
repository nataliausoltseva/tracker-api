using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Tracker.Models
{
    public class TrackerContext : DbContext
    {
        public TrackerContext (DbContextOptions<TrackerContext> options)
            : base(options)
        {
        }

        public DbSet<Tracker.Models.TrackerItem> TrackerItem { get; set; }
    }
}
