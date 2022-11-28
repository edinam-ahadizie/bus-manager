using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectAPI.Models;
using projectAPI.Utils;

namespace projectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly VipContext _context;

        public TripsController(VipContext context)
        {
            _context = context;
        }

        // GET: api/Workouts
        [HttpGet]
        public PaginationResult<Trips> GetTrip([FromQuery] DefaultArgs args)
        {
            if (args.Filter == null || args.Filter.Length == 0)
            {
                return _context.Trips.Include(t => t.Driver).Include(t => t.Bus).Paginate(args);
            }

            args.Filter = args.Filter.ToLower();
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(args.Filter);

            IQueryable<Trips> query = _context.Trips.Include(t => t.Driver).Include(t => t.Bus).Where(
                  u => regex.IsMatch(u.Trip.ToLower()) ||
                     regex.IsMatch(u.TripDate.ToLongDateString())
             );
            

            Console.WriteLine("Filter:: " + args.Filter);
            return query.Paginate(args);
        }

        // GET: api/Workouts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrip([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var trip = await _context.Trips.Include(t => t.Driver).Include(t => t.Bus).SingleOrDefaultAsync(m => m.Id == id);

            if (trip == null)
            {
                return NotFound();
            }

            return Ok(trip);
        }

        // PUT: api/Workouts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrip([FromRoute] int id, [FromBody] Trips trip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trip.Id)
            {
                return BadRequest();
            }

            _context.Entry(trip).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TripExists(id))
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

        private bool TripExists(int id)
        {
            return _context.Trips.Any(e => e.Id == id);
        }

        // POST: api/Workouts
        [HttpPost]
        public async Task<IActionResult> PostTrip([FromBody] Trips trip)
        {
            Console.WriteLine("TripType" + trip.TripProfit);
            // kindly rerun this for me!!!!!! EDINAM!
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Trips.Add(trip);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostTrip", trip);
        }
        // DELETE: api/Workouts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrip([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var trip = await _context.Trips.SingleOrDefaultAsync(m => m.Id == id);
            if (trip == null)
            {
                return NotFound();
            }

            _context.Trips.Remove(trip);
            await _context.SaveChangesAsync();

            return Ok(trip);
        }
    }
}