using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ManteHos.Entities
{
    public partial class UsedPart
    {
        [Key]public int Id 
        { 
            get; 
            set; 
       }
        [Required] public int Quantity
        {
            get;
            set;
        }
        [Required]public Boolean Needed
        {
            get;
            set;
        }
        [Required]public virtual Part Part
        {
            get;
            set;
        }
        public virtual ICollection<WorkOrder> WorkOrders
        {
            get;
            set;
        }

    }
}
