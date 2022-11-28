using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace projectAPI.Models
{
    public class Sales
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Cost { get; set; }
        public int Passengers { get; set; }
        public int Amount { get; set; }
        public string Drivername { get; set; }
        public string Busnum { get; set; }
        public DateTime SaleDate { get; set; }
        public Nullable<int> TripId { get; set; }
        public Trips Trip { get; set; }
        public Bus Bus { get; set; }
        public Nullable<int> BusId { get; set; }
        public Driver Driver { get; set; }
        public Nullable<int> DriverId { get; set; }

    }
}
