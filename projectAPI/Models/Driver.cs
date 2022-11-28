using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace projectAPI.Models
{
    public class Driver
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [NotMapped]
        public string FullName => FirstMidName + " " + LastName;
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime Dob { get; set; }
        public string Status { get; set; }
        public int Salary { get; set; }
        public int Performance { get; set; }
        public int Phone { get; set; }
        public string License { get; set; }
        public string Picture { get; set; }
        public Nullable<int> BusId { get; set; }
        public Bus Bus { get; set; }
    }
}
 