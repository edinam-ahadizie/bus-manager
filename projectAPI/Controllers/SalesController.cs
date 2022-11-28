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
    public class SalesController : ControllerBase
    {
        private readonly VipContext _context;

        public SalesController(VipContext context)
        {
            _context = context;
        }

        // GET: api/Sales
        [HttpGet]
        public PaginationResult<Sales> GetSale([FromQuery] DefaultArgs args)
        {
            if (args.Filter == null || args.Filter.Length == 0)
            {
                return _context.Sales.Include(t => t.Trip).Include(t => t.Bus).Include(t => t.Driver).Paginate(args);
            }

            args.Filter = args.Filter.ToLower();
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(args.Filter);

            IQueryable<Sales> query = _context.Sales.Include(t => t.Trip).Include(t => t.Bus).Include(t => t.Driver).Where(
                 // u => regex.IsMatch(u.Driver.LastName.ToLower() + " " + u.Driver.FirstMidName.ToLower()) ||
                   u =>  
                   regex.IsMatch(u.SaleDate.Month.ToString()) ||
                       regex.IsMatch(u.Trip.Trip.ToString())||
                       regex.IsMatch(u.Bus.BusNumber)
             );


            Console.WriteLine("Filter:: " + args.Filter);
            return query.Paginate(args);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSale([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sales = await _context.Sales.Include(t => t.Trip).Include(t => t.Bus).Include(t => t.Driver).SingleOrDefaultAsync(m => m.Id == id);

            if (sales == null)
            {
                return NotFound();
            }

            return Ok(sales);
        }


        [HttpGet("test")]
        public int Test([FromQuery] string datetime)
        {
            DateTime date = DateTime.Parse(datetime);
            int val = Utilities.getWeekNum(date);
           return val;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutSale([FromRoute] int id, [FromBody] Sales sale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sale.Id)
            {
                return BadRequest();
            }


            // we store this value when we add or update
            sale.Amount = sale.Cost * sale.Passengers;

            _context.Entry(sale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleExists(id))
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

        private bool SaleExists(int id)
        {
            return _context.Sales.Any(e => e.Id == id);
        }

        [HttpPost]
        public async Task<IActionResult> PostSale([FromBody] Sales sale)
        {
            Console.WriteLine("Sale" + sale.Cost);
            // kindly rerun this for me!!!!!! EDINAM!
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // we store this value when we add or update
            sale.Amount = sale.Cost * sale.Passengers;

            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostSale", sale);
        }
        // DELETE: api/Workouts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletSale([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sale = await _context.Sales.SingleOrDefaultAsync(m => m.Id == id);
            if (sale == null)
            {
                return NotFound();
            }

            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();

            return Ok(sale);
        }
    }
}
