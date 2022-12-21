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
    public partial class Frm_Rpt_Marcas : Form
    {
        public Frm_Rpt_Marcas()
        {
            InitializeComponent();
        }

        private void Frm_Rpt_Marcas_Load(object sender, EventArgs e)
        {
            this.uSP_Listado_maTableAdapter.Fill(this.dS_Reportes.USP_Listado_ma, Texto: textBox1.Text);
            this.reportViewer1.RefreshReport();
        }
    }
}
