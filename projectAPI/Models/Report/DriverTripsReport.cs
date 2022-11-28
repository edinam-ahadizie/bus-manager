using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace projectAPI.Models.Report
{
    public class DriverTripsReport
    {

        public Driver Driver { get; set; }

        public int DriverId { get; set; }

        public int Count { get; set; }
    }
}
