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
    public class PerformanceController : ControllerBase
    {

        private readonly VipContext _context;

        public PerformanceController(VipContext context)
        {
            _context = context;
        }

        // GET: api/Performance
        [HttpGet()]
        public PaginationListResult<Performance> GetPerformance([FromQuery] DefaultArgs args)
        {
            var listDriver = _context.Driver.ToArray();
            List<Performance> performances = new List<Performance>();

            foreach(Driver driver in listDriver)
            {
                var perf = new Performance();
                perf.Driver = driver;
                perf.PerformanceValue = Utilities.getDriverPreformance(_context, driver);

                performances.Add(perf);
                Console.WriteLine("DRIVER:: " + driver.Id);
                Console.WriteLine("PERF:: " + performances.Count());
            }


            PaginationListResult<Performance> results = new PaginationListResult<Performance>();
            results.total = _context.Driver.Count();
            results.page = args.PageNumber + 1;
            results.data = performances;

            return results;
        }

    }
}