using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tracker.Models;

namespace Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackerController : ControllerBase
    {
        private readonly TrackerContext _context;

        public TrackerController(TrackerContext context)
        {
            _context = context;
        }

        // GET: api/Tracker
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrackerItem>>> GetTrackerItem()
        {
            return await _context.TrackerItem.ToListAsync();
        }

        // GET: api/Tracker/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrackerItem>> GetTrackerItem(int id)
        {
            var trackerItem = await _context.TrackerItem.FindAsync(id);

            if (trackerItem == null)
            {
                return NotFound();
            }

            return trackerItem;
        }

        // PUT: api/Tracker/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrackerItem(int id, TrackerItem trackerItem)
        {
            if (id != trackerItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(trackerItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackerItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tracker
        [HttpPost]
        public async Task<ActionResult<TrackerItem>> PostTrackerItem(TrackerItem trackerItem)
        {
            _context.TrackerItem.Add(trackerItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrackerItem", new { id = trackerItem.Id }, trackerItem);
        }

        // DELETE: api/Tracker/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrackerItem>> DeleteTrackerItem(int id)
        {
            var trackerItem = await _context.TrackerItem.FindAsync(id);
            if (trackerItem == null)
            {
                return NotFound();
            }

            _context.TrackerItem.Remove(trackerItem);
            await _context.SaveChangesAsync();

            return trackerItem;
        }

        private bool TrackerItemExists(int id)
        {
            return _context.TrackerItem.Any(e => e.Id == id);
        }
    }
}
