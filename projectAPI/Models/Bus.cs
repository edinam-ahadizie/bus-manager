using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace projectAPI.Models
{
    public class Bus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto Increment
        public int Id { get; set; }
        [Required]
        public string BusNumber { get; set; }
        public string BusType { get; set; }
        public int Capacity { get; set; }
        public DateTime RegistrationYear { get; set; }
        //public string DriverName { get; set; }

    }
}