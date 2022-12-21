using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Reportes
{
    public partial class Frm_Rpt_Entrada_Prod : Form
    {
        public Frm_Rpt_Entrada_Prod()
        {
            InitializeComponent();
        }

        private void Frm_Rpt_Entrada_Prod_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
