using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectAPI.Models;
using projectAPI.Models.Report;
using projectAPI.Utils;

namespace projectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {

            private readonly VipContext _context;

            public SalaryController(VipContext context)
            {
                _context = context;
            }

            // GET: api/DateFilter
            [HttpGet]
            public PaginationResult<Salary> GetSalary([FromQuery] DefaultArgs args)
            {
                if (args.Filter == null || args.Filter.Length == 0)
                {
                    return _context.Salary.Include(t => t.Driver).Paginate(args);
                }



                args.Filter = args.Filter.ToLower();
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(args.Filter);

                IQueryable<Salary> query = _context.Salary.Include(t => t.Driver).Where(
                      u => regex.IsMatch(u.Driver.LastName.ToLower() + " " + u.Driver.FirstMidName.ToLower()) ||
                            u.PaymentDate.Month == Utilities.GetMonthNum(args.Filter) ||
                           regex.IsMatch(u.PayStatus.ToString())
                 );

                Console.WriteLine("Filter:: " + args.Filter);
                return query.Paginate(args);
            }

        // GET: api/Salary/DateFilter
        [HttpGet("DateFilter")]
        public PaginationResult<Salary> GetDateFilterSalary([FromQuery] DefaultArgs args, [FromQuery] string StartDate, [FromQuery] string EndDate)
        {
            if (StartDate == null || EndDate == null)
            {
                return null;
            }

            DateTime date1 = DateTime.Parse(StartDate);
            DateTime date2 = DateTime.Parse(EndDate);

            IQueryable<Salary> query = _context.Salary.Include(t => t.Driver).Where(
                  u => u.PaymentDate >= date1 && u.PaymentDate <= date2
             );

            /*
            var sales = _context.Sales.Where(
                  u => u.SaleDate >= date1 && u.SaleDate <= date2
             ).Sum(u => u.Amount);

            var maintenance = _context.Maintenance.Where(
                  u => u.MaintenanceDate >= date1 && u.MaintenanceDate <= date2
             ).Sum(u => u.MaintenanceCost);

            var profit = sales - maintenance;
            */

            return query.Paginate(args);
        }

        [HttpGet("{id}")]
            public async Task<IActionResult> GetSalary([FromRoute] int id)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var salary = await _context.Salary.Include(t => t.Driver).SingleOrDefaultAsync(m => m.Id == id);

                if (salary == null)
                {
                    return NotFound();
                }

                return Ok(salary);
            }
            [HttpPost]
            public async Task<IActionResult> PostSalary([FromBody] Salary salary)
            {
                // kindly rerun this for me!!!!!! EDINAM!
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.Salary.Add(salary);
                await _context.SaveChangesAsync();

                return CreatedAtAction("PostSalary", salary);
            }
            // DELETE: api/Workouts/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteSalary([FromRoute] int id)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var salary = await _context.Salary.SingleOrDefaultAsync(m => m.Id == id);
                if (salary == null)
                {
                    return NotFound();
                }

                _context.Salary.Remove(salary);
                await _context.SaveChangesAsync();

                return Ok(salary);
            }
        }
    }
