using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NinjaNye.SearchExtensions;
using Microsoft.EntityFrameworkCore;
using projectAPI.Models;
using projectAPI.Utils;

namespace projectAPI.Controllers
{
 
    [Route("api/[controller]")]
   // [Authorize]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly VipContext _context;

        public BusController(VipContext context)
        {
            _context = context;
        }

        // GET: api/Workouts
        [HttpGet]
        public PaginationResult<Bus> GetBus([FromQuery] DefaultArgs args)
        {
            if (args.Filter == null || args.Filter.Length == 0)
            {
                return _context.Bus.Paginate(args);
            }

            args.Filter = args.Filter.ToLower();
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(args.Filter);

            IQueryable<Bus> query = _context.Bus.Where(
                u => regex.IsMatch(u.BusNumber.ToLower()) ||
                     regex.IsMatch(u.BusType.ToLower())
             );

            Console.WriteLine("Filter:: " + args.Filter);
            return query.Paginate(args);
        }
        

        // GET: api/Bus/Typeahead?personType=Customer
        [HttpGet("Typeahead")]
        public ICollection<Typeahead> GetBusTypeahead([FromQuery] string Filter)
        {
            if (Filter == null || Filter.Length == 0)
            {
                return null;
            }

            Filter = Filter.ToLower();
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(Filter);

            IQueryable<Bus> query = _context.Bus.Where(
                u => regex.IsMatch(u.BusNumber.ToLower()) ||
                     regex.IsMatch(u.BusType.ToLower())
             );

            Console.WriteLine("Filter:: " + Filter);

            ICollection<Typeahead> typeaheadList = new Collection<Typeahead>();
            foreach (Bus item in query.Take(10))
            {
                typeaheadList.Add(new Typeahead
                {
                    Id = item.Id,
                    Value = item.BusNumber + " (" + item.BusType + ")"
                });
            }

            return typeaheadList;
        }

        // GET: api/Workouts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBus([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bus = await _context.Bus.SingleOrDefaultAsync(m => m.Id == id);

            if (bus == null)
            {
                return NotFound();
            }

            return Ok(bus);
        }

        // PUT: api/Workouts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBus([FromRoute] int id, [FromBody] Bus bus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bus.Id)
            {
                return BadRequest();
            }

            _context.Entry(bus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusExists(id))
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

        private bool BusExists(int id)
        {
            return _context.Bus.Any(e => e.Id == id);
        }

        // POST: api/Workouts
        [HttpPost]
        public async Task<IActionResult> PostBus([FromBody] Bus bus)
        {
            Console.WriteLine("BusNumber" + bus.BusNumber);
            // kindly rerun this for me!!!!!! EDINAM!
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Bus.Add(bus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBus", new { id = bus.Id }, bus);
        }
        // DELETE: api/Workouts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBus([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bus = await _context.Bus.SingleOrDefaultAsync(m => m.Id == id);
            if (bus == null)
            {
                return NotFound();
            }

            _context.Bus.Remove(bus);
            await _context.SaveChangesAsync();

            return Ok(bus);
        }

    }
}