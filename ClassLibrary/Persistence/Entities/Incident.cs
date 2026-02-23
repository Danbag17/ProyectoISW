using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ManteHos.Entities
{
    public partial class Incident
    {
        [Key] public int Id { get; set; }
        [Required] public String Description { get; set; }
        [Required] public DateTime ReportDate { get; set; }
        [Required] public string Department { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public string RejectReason { get; set; }
        public float Cost { get; set; }


        //Relaciones
        [InverseProperty("Incidents")]
        public virtual Area Area { get; set; }
        [Required, InverseProperty("ReportedIncidents")]
        public virtual Employee Reporter { get; set; }
        [InverseProperty("Incident")]
        public virtual WorkOrder WorkOrder { get; set; }
    }
}
