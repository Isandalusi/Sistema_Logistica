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
    public partial class Frm_Reporte_Ingreso_ComprasxProductos : Form
    {
        public Frm_Reporte_Ingreso_ComprasxProductos()
        {
            InitializeComponent();
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_VPrevia_Click(object sender, EventArgs e)
        {
            Repotes_Bitacora.Frm_Rpt_Ingreso_ComprasxProductos oRpt_ICP = new Frm_Rpt_Ingreso_ComprasxProductos();
            oRpt_ICP.txt1.Text = Convert.ToString(dt_Fecha_ini.Value);
            oRpt_ICP.txt2.Text = Convert.ToString(dt_Fecha_fin.Value);
            oRpt_ICP.Show();

        }
    }
}
