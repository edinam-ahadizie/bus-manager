using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace projectAPI.Models
{
    public class Maintenance
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto Increment
        public int Id { get; set; }
        [Required]
        public string MaintenanceType { get; set; }
        public int MaintenanceCost { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public Nullable<int> BusId { get; set; }
        public Bus Bus { get; set; }
    }
}
