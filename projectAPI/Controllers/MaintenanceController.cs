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
    public class MaintenanceController : ControllerBase
    {

        private readonly VipContext _context;

        public MaintenanceController(VipContext context)
        {
            _context = context;
        }

        // GET: api/Workouts
        [HttpGet]
        public PaginationResult<Maintenance> GetMaintenance([FromQuery] DefaultArgs args)
        {
            if (args.Filter == null || args.Filter.Length == 0)
            {
                return _context.Maintenance.Include(t => t.Bus).Paginate(args);
            }

            args.Filter = args.Filter.ToLower();
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(args.Filter);

            IQueryable<Maintenance> query = _context.Maintenance.Include(t => t.Bus).Where(
                  u => regex.IsMatch(u.MaintenanceType.ToLower()) ||
                     regex.IsMatch(u.MaintenanceDate.ToShortDateString())
             );

            Console.WriteLine("Filter:: " + args.Filter);
            return query.Paginate(args);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaintenance([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var main = await _context.Maintenance.Include(t => t.Bus).SingleOrDefaultAsync(m => m.Id == id);

            if (main == null)
            {
                return NotFound();
            }

            return Ok(main);
        }
        [HttpPost]
        public async Task<IActionResult> PostMaintenance([FromBody] Maintenance main)
        {
            Console.WriteLine("Maintenance" + main.MaintenanceDate);
            // kindly rerun this for me!!!!!! EDINAM!
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Maintenance.Add(main);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostMaintenance", main);
        }
        // DELETE: api/Workouts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaintenance([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var main = await _context.Maintenance.SingleOrDefaultAsync(m => m.Id == id);
            if (main == null)
            {
                return NotFound();
            }

            _context.Maintenance.Remove(main);
            await _context.SaveChangesAsync();

            return Ok(main);
        }
    }
}