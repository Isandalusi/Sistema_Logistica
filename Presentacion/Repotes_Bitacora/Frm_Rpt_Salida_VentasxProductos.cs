using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Repotes_Bitacora
{
    public partial class Frm_Rpt_Salida_VentasxProductos : Form
    {
        public Frm_Rpt_Salida_VentasxProductos()
        {
            InitializeComponent();
        }

        private void Frm_Rpt_Salida_VentasxProductos_Load(object sender, EventArgs e)
        {
            this.uSP_Reporte_Salida_VentasxProductosTableAdapter.Fill(this.dataset_Reportes_Bitacora.USP_Reporte_Salida_VentasxProductos, Fecha_ini: Convert.ToDateTime(txt1.Text), Fecha_fin: Convert.ToDateTime(txt2.Text));
            this.reportViewer1.RefreshReport();
        }
    }
}
