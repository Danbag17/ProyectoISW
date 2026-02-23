using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class WorkOrder
    {
        public WorkOrder() {

            Operators = new List<Operator>();
            UsedParts = new List<UsedPart>();
        }
        public WorkOrder(DateTime StartDate, Incident Incident) :this() {
            this.StartDate = StartDate;
            this.Incident = Incident;
        }
        // Implementación trivial para el Persistence Test
        public UsedPart AddUsedPart(int aQuantity, Part aPart)
        {
            UsedPart uP = new UsedPart(aQuantity, aPart);
            UsedParts.Add(uP);
            return uP;
        }
        public void AddOperator(Operator op)
        {
            if (op != null)
            {
                // Añadimos el operario a la orden
                if (!this.Operators.Contains(op))
                {
                    this.Operators.Add(op);

                    // IMPORTANTE: Asegurar que el operario también conozca la orden 
                    // si la relación está definida en ambos sentidos en tu modelo
                    if (!op.WorkOrders.Contains(this))
                    {
                        op.WorkOrders.Add(this);
                    }
                }
            }
        }


    }
}
