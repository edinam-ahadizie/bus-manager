using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using projectAPI.Models;
using projectAPI.Utils;

namespace projectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly VipContext _context;

        public ReportsController(VipContext context)
        {
            _context = context;
        }

        // GET: api/Reports
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
                  u => regex.IsMatch(u.Bus.BusNumber.ToString().ToLower()) 
             //regex.IsMatch(u.Bus.BusNumber)
             );


            var TotalSales = _context.Trips.Select(t => t.TripMaintenancecost
                ).Sum();

            var TotalMaint = _context.Trips.Select(t => t.TripMaintenancecost
                ).Sum();

            var AllProfit = TotalSales - TotalMaint;

            int totaltripCount = _context.Trips.Select(
               t => t.Id
               ).Count();

            int totalbusCount = _context.Trips.Select(
               t => t.BusId
               ).Count();

            int totaldriverCount = _context.Trips.Select(
               t => t.DriverId
               ).Count();



            Console.WriteLine("Filter:: " + args.Filter);
            return query.Paginate(args);
        }

        // GET: api/Reports
        [HttpGet("NoTrips")]
        public PaginationResult<Driver> GetNoTrips([FromQuery] DefaultArgs args, [FromQuery] string StartDate, [FromQuery] string EndDate)
        {
            if (StartDate == null || EndDate == null)
            {
                return null;
            }

            DateTime date1 = DateTime.Parse(StartDate);
            DateTime date2 = DateTime.Parse(EndDate);
        
            // Get list of all driver ids
            // get a list of all (distinct) driver Ids in trips
            var  driverIds = _context.Trips.Where(u => u.TripDate >= date1 && u.TripDate <= date2).Select(u => u.DriverId).Distinct().ToArray();
            // compare both arrays and remove similar ids
            // the remaining will be the driver who have no trips
            IQueryable<Driver> query = _context.Driver.Include(u => u.Bus).Where(u => !driverIds.Contains(u.Id));
          

          
            
            return query.Paginate(args);
        }

        [HttpGet("DateFilter")]
        public PaginationResult<Trips> GetDateFilterReports([FromQuery] DefaultArgs args, [FromQuery] string StartDate, [FromQuery] string EndDate)
        {
            if (StartDate == null || EndDate == null)
            {
                return null;
            }

            DateTime date1 = DateTime.Parse(StartDate);
            DateTime date2 = DateTime.Parse(EndDate);

              IQueryable<Trips> query = _context.Trips.Include(t => t.Driver).Include(t => t.Bus).Where(
                    u => u.TripDate >= date1 && u.TripDate <= date2
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
    }
}