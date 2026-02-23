using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ManteHos.Entities
{
    public partial class WorkOrder
    {
        [Key]public int Id
        {
            get;
            set;
        }
        [Required]public DateTime StartDate
        {
            get;
            set;
        }
        public DateTime EndDate
        {
            get;
            set;
        }
        public String RepairReport
        {
            get;
            set;
        }
        public virtual ICollection<Operator> Operators
        {
            get;
            set;
        }
        public virtual ICollection<UsedPart> UsedParts
        {
            get;
            set;
        }
        [Required]public virtual Incident Incident
        {
            get;
            set;
        }
    }
}
