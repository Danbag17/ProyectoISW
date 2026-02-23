using ManteHos.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManteHosGUI
{
    
        public partial class ManteHosFormBase : Form
        {
            // La variable protegida para que los hijos la puedan usar
            protected IManteHosService service = null;

            public ManteHosFormBase()
            {
                InitializeComponent();
            }

            // Este es el constructor que permite pasar el servicio
            public ManteHosFormBase(IManteHosService s) : this()
            {
                this.service = s;
            }

        private void ManteHosFormBase_Load(object sender, EventArgs e)
        {

        }
    }
}
