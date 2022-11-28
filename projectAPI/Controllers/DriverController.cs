using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class DriverController : ControllerBase
    {
        private readonly VipContext _context;

        public DriverController(VipContext context)
        {
            _context = context;
        }

        // GET: api/Workouts
        [HttpGet]
        public PaginationResult<Driver> GetDriver([FromQuery] DefaultArgs args)
        {
            if (args.Filter == null || args.Filter.Length == 0)
            {
                return _context.Driver.Include(t => t.Bus).Paginate(args);
            }

            args.Filter = args.Filter.ToLower();
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(args.Filter);

            IQueryable<Driver> query = _context.Driver.Include(t => t.Bus).Where(
                u => regex.IsMatch(u.FirstMidName.ToLower() + " " + u.LastName.ToLower()) ||
                            regex.IsMatch(u.LastName.ToLower() + " " + u.FirstMidName.ToLower()) ||
                            regex.IsMatch(u.FirstMidName.ToLower()) ||
                            regex.IsMatch(u.LastName.ToLower())
             );

            Console.WriteLine("Filter:: " + args.Filter);
            return query.Paginate(args);
        }

        // GET: api/Workouts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDriver([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var driver = await _context.Driver.Include(t => t.Bus).SingleOrDefaultAsync(m => m.Id == id);

            if (driver == null)
            {
                return NotFound();
            }

            return Ok(driver);
        }

        // GET: api/Driver/Typeahead?personType=Customer
        [HttpGet("Typeahead")]
        public ICollection<Typeahead> GetDriverTypeahead([FromQuery] string Filter)
        {
            if (Filter == null || Filter.Length == 0)
            {
                return null;
            }

            Filter = Filter.ToLower();
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(Filter);

            IQueryable<Driver> query = _context.Driver.Where(
                u => regex.IsMatch(u.FirstMidName.ToLower() + " " + u.LastName.ToLower()) ||
                            regex.IsMatch(u.LastName.ToLower() + " " + u.FirstMidName.ToLower()) ||
                            regex.IsMatch(u.FirstMidName.ToLower()) ||
                            regex.IsMatch(u.LastName.ToLower())
                );

            Console.WriteLine("Filter:: " + Filter);

            ICollection<Typeahead> typeaheadList = new Collection<Typeahead>();
            foreach (Driver item in query.Take(10))
            {
                typeaheadList.Add(new Typeahead
                {
                    Id = item.Id,
                    Value = item.FirstMidName + " " + item.LastName
                });
            }

            return typeaheadList;
        }

        // PUT: api/Workouts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBus([FromRoute] int id, [FromBody] Driver driver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != driver.Id)
            {
                return BadRequest();
            }

            _context.Entry(driver).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverExists(id))
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

        private bool DriverExists(int id)
        {
            return _context.Driver.Any(e => e.Id == id);
        }

        // POST: api/Workouts
        [HttpPost]
        public async Task<IActionResult> PostDriver([FromBody] Driver driver)
        {
            Console.WriteLine("LastName" + driver.LastName);
            // kindly rerun this for me!!!!!! EDINAM!
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Driver.Add(driver);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDriver", new { id = driver.Id }, driver);
        }
        // DELETE: api/Workouts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriver([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var driver = await _context.Driver.SingleOrDefaultAsync(m => m.Id == id);
            if (driver == null)
            {
                return NotFound();
            }

            _context.Driver.Remove(driver);
            await _context.SaveChangesAsync();

            return Ok(driver);
        }

    }
}
