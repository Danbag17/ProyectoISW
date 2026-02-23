using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ManteHos.Entities
{
    public partial class Employee
    {
        [Required]public string FullName
        {
            get; set;
        }
        [Key]public string Id
        {
            get; set;
        }
        [Required]public string Password
        {
            get; set;
        }
        
        public virtual ICollection<Incident> ReportedIncidents { get; set; }

    }
}
