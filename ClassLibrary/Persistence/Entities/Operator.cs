using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class Operator : Employee
    {
        public Shift Shift { get; set; }
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }

        public virtual Area Area { get; set; }
    }
}
