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
    public partial class Frm_Rpt_Ingreso_ComprasxProductos : Form
    {
        public Frm_Rpt_Ingreso_ComprasxProductos()
        {
            InitializeComponent();
        }

        private void Frm_Rpt_Ingreso_ComprasxProductos_Load(object sender, EventArgs e)
        {
            this.uSP_Reporte_Ingreso_ComprasxProductosTableAdapter.Fill(this.dataset_Reportes_Bitacora.USP_Reporte_Ingreso_ComprasxProductos, Fecha_ini:Convert.ToDateTime(txt1.Text),Fecha_fin: Convert.ToDateTime(txt2.Text));
            this.reportViewer1.RefreshReport();
        }
    }
}
