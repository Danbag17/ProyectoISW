using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ManteHos.Entities
{
    public partial class Part
    {
        [Key]public String Code { 
            get; 
            set;
            
        }
       [Required] public String Description
        {
            get;
            set;

        }
        [Required]public float UnitPrice
        {
            get;
            set;

        }
        [Required]public int CurrentQuantity { 
            get; 
            set; 
        }
        [Required]public int MinimunQuantity
        {
            get;
            set;

        }
        [Required]public String UnitOfMeasure
        {
            get;
            set;

        }

        public virtual ICollection<UsedPart> UsedParts
        { 
            get; 
            set; 
        }
    }
    
}
