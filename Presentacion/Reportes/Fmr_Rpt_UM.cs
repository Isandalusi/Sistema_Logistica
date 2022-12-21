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
    public partial class Fmr_Rpt_UM : Form
    {
        public Fmr_Rpt_UM()
        {
            InitializeComponent();
        }

        private void Fmr_Rpt_UM_Load(object sender, EventArgs e)
        {
            this.uSP_Listado_umTableAdapter.Fill(this.dS_Reportes.USP_Listado_um, Texto: textBox1.Text);
            this.reportViewer1.RefreshReport();
        }
    }
}
