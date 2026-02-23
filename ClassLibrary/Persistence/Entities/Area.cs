using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ManteHos.Entities
{
    public partial class Area
    {
        [Required]public String Name         {
            get; set;
           
        }
        [Key]public int Id
        {
            get; set;
        }
        [Required]public virtual Master Master
        {
            get;    set;
        }
        
        public virtual ICollection<Incident> Incidents
        {
            get; set;
        }

    }
}
