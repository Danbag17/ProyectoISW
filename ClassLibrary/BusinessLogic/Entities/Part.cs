using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class Part
    {
        public Part() {
            UsedParts = new List<UsedPart>();
        }
        public Part(string Code, int CurrentQuantity, string Description, int MinimunQuantity, string UnitOfMeasure, float UnitPrice)
        {
            {
                this.Code = Code;
                this.CurrentQuantity = CurrentQuantity;
                this.Description = Description;
                this.MinimunQuantity = MinimunQuantity;
                this.UnitOfMeasure = UnitOfMeasure;
                this.UnitPrice = UnitPrice;

                UsedParts = new List<UsedPart>();
            }
        }
    }
}
