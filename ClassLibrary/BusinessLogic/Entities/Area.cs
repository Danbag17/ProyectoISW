using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManteHos.Entities;

namespace ManteHos.Entities
{
    public partial class Area
    {
        public Area() {
            Incidents = new List<Incident>();
        }

        public Area(String name, Master masters)
        {
            this.Name = name;
            this.Master = masters;
            //Colecciones
            Incidents = new List<Incident>();
        }
    }
}
