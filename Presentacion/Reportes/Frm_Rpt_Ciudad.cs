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
    public partial class Frm_Rpt_Ciudad : Form
    {
        public Frm_Rpt_Ciudad()
        {
            InitializeComponent();
        }

        private void Frm_Rpt_Ciudad_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
