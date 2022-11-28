using projectAPI.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace projectAPI.Models
{
    public class Trips
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Trip { get; set; }
        public int Waybill { get; set; }
        public string TripMaintenancetype { get; set; }
        public int TripMaintenancecost { get; set; }
        //public int TripWeek { get; set; }
        [NotMapped]
        public int TripWeek => Utilities.getWeekNum(TripDate);
        public int TripSales { get; set; }
        public int TripProfit { get; set; }

        public DateTime TripDate { get; set; }

        public Bus Bus { get; set; }
        public int BusId { get; set; }

        public Driver Driver { get; set; }
        public int DriverId { get; set; }

        public bool IsStandby { get; set; }
        [NotMapped]
        public int TotalProfits { get; set; }
        [NotMapped]
        public int TotalMaintenance { get; set;}
        [NotMapped]
        public int TotalSales { get; set; }

    }
}
