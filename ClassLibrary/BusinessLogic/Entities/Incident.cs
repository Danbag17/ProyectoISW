using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class Incident
    {
        public Incident() { }
        public Incident(string department, string description, DateTime reportdate, 
                         Employee reporter) :this() {
            
            this.Description = description;
            this.Department = department;
            this.Reporter = reporter;
            this.ReportDate = reportdate;
            this.Status = Status.Created;
        }

    }
}
