using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TrackerContext(
                serviceProvider.GetRequiredService<DbContextOptions<TrackerContext>>()))
                {
                if (context.TrackerItem.Count() > 0)
                {
                    return;
                }

                context.TrackerItem.AddRange(
                    new TrackerItem
                    {
                        Weight = 66.00,
                        GoalWeight = 60.00,
                        Name = "Nat",
                        Date = new DateTime(2019, 08, 15, 12, 30, 0, 0)
                    }
                    );
                context.SaveChanges();
            }
        }

        internal void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
