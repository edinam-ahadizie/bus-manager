using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace projectAPI.Models
{
    public class Salary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto Increment
        public int Id { get; set; }
        [Required]
        public int AmountPaid { get; set; }
        public bool PayStatus { get; set; }
        public DateTime PaymentDate { get; set; }
        public Nullable<int> DriverId { get; set; }
        public Driver Driver { get; set; }
    }
}
