using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projectAPI.Models;
using projectAPI.Utils;

namespace projectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfitController : ControllerBase
    {
        private readonly VipContext _context;

        public ProfitController(VipContext context)
        {
            _context = context;
        }

        // GET: api/Performance
        [HttpGet()]
        public PaginationListResult<Profit> GetProfit([FromQuery] DefaultArgs args)
        {
            var listDriver = _context.Driver.ToArray();
            List<Profit> profits = new List<Profit>();

            foreach (Driver driver in listDriver)
            {
                var prof = new Profit();
                prof.Driver = driver;
                prof.ProfitAmount = Utilities.getProfits(_context, driver);

                profits.Add(prof);
                Console.WriteLine("DRIVER:: " + driver.Id);
                Console.WriteLine("PERF:: " + profits.Count());
            }


            PaginationListResult<Profit> results = new PaginationListResult<Profit>();
            results.total = _context.Driver.Count();
            results.page = args.PageNumber + 1;
            results.data = profits;

            return results;
        }
    }
}