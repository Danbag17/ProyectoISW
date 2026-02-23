using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class UsedPart
    {
        public UsedPart() { }

        public UsedPart(int quantity, Part part) {
            
            this.Quantity = quantity;
            this.Part = part;

            if (part.CurrentQuantity < quantity)
            {
                // No hay suficiente → Needed = true
                this.Needed = true;
            }
            else
            {
                // Hay suficiente → descontar stock y Needed = false
                part.CurrentQuantity -= quantity;
                this.Needed = false;
            
            }
        }
    }
}
