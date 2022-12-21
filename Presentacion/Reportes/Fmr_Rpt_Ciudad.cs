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
    public partial class Fmr_Rpt_Ciudad : Form
    {
        public Fmr_Rpt_Ciudad()
        {
            InitializeComponent();
        }

        private void Fmr_Rpt_Ciudad_Load(object sender, EventArgs e)
        {
            this.uSP_Listado_ciTableAdapter.Fill(this.dS_Reportes.USP_Listado_ci, Texto: textBox1.Text);
            this.reportViewer1.RefreshReport();
        }
    }
}
