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
    public partial class Fmr_Rpt_Entrada_Producto : Form
    {
        public Fmr_Rpt_Entrada_Producto()
        {
            InitializeComponent();
        }

        private void Fmr_Rpt_Entrada_Producto_Load(object sender, EventArgs e)
        {
            this.uSP_Listado_epTableAdapter.Fill(this.dS_Reportes.USP_Listado_ep, Texto: textBox1.Text);
            this.reportViewer1.RefreshReport();
        }
    }
}
