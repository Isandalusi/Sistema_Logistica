using Presentacion.Reportes;
using Presentacion.Repotes_Bitacora;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Presentacion
{
    public partial class Frm_DashBoard : Form
    {
        public Frm_DashBoard()
        {
            InitializeComponent();
        }


        #region "Mis Variables"

        private Form activarForm=null;


        #endregion
        #region "Mis Metodos"

        private void OpenChildForm(Form childForm)
        {
            if (activarForm!=null)
            {
                activarForm.Close();
            }
            activarForm=childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle=FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            Panel_Detalle.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }


        #endregion

        private void Frm_DashBoard_Load(object sender, EventArgs e)
        {
            this.Panel_Datos.Visible = false;
            this.Panel_Reportes.Visible = false;
            this.Panel_Movimientos.Visible=false;
            this.Panel_Sistemas.Visible=false;  
            
        }

       
        

        private void Btn_Mov_Click(object sender, EventArgs e)
        {
            if (this.Panel_Movimientos.Visible==false)
            {
                this.Panel_Movimientos.Visible=true;
            }
            else
            {
                this.Panel_Movimientos.Visible = false;
            }
            this.Panel_Datos.Visible = false;
            this.Panel_Reportes.Visible = false;
            this.Panel_Sistemas.Visible = false;

        }

        private void btn_Reportes_Click(object sender, EventArgs e)
        {
            if (this.Panel_Reportes.Visible == false)
            {
                this.Panel_Reportes.Visible = true;
            }
            else
            {
                this.Panel_Reportes.Visible = false;
            }
            this.Panel_Datos.Visible = false;
            this.Panel_Movimientos.Visible = false;
            this.Panel_Sistemas.Visible = false;
        }

        private void Btn_DatosG_Click(object sender, EventArgs e)
        {
            if (this.Panel_Datos.Visible == false)
            {
                this.Panel_Datos.Visible = true;
            }
            else
            {
                this.Panel_Datos.Visible = false;
            }
           
            this.Panel_Reportes.Visible = false;
            this.Panel_Movimientos.Visible = false;
            this.Panel_Sistemas.Visible = false;
        }

        private void btn_Sistemas_Click(object sender, EventArgs e)
        {
            if (this.Panel_Sistemas.Visible == false)
            {
                this.Panel_Sistemas.Visible = true;
            }
            else
            {
                this.Panel_Sistemas.Visible = false;
            }
            this.Panel_Datos.Visible = false;
            this.Panel_Reportes.Visible = false;
            this.Panel_Movimientos.Visible = false;
           
        }

        private void btn_Ep_Click(object sender, EventArgs e)
        {
            
            OpenChildForm(new Frm_Entrada_Productos());

        }

        private void btn_Sp_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_Salida_Productos());
        }

        private void btn_Reporte1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_Reporte_Ingreso_ComprasxProductos());
        }

        private void Btn_Reporte2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_Reporte_Salida_VentasxProductos());
        }

        private void btn_Productos_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_Productos());
        }

        private void btn_Marca_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_Marcas());
        }

        private void btn_Medidas_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_Unidades_Medidas());
        }

        private void btn_Categoria_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmCategoria());
        }

        private void btn_Almacenes_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_Almacenes());
        }

        private void btn_Clientes_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_Clientes());
        }

        private void btn_Proveedores_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_Proveedores());
        }

        private void btn_Rubros_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_Rubros());
        }

        private void btn_Ciudades_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_Ciudad());
        }

        private void btn_Provincias_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_Provincias());
        }

        private void btn_Paises_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_PAISES());
        }

        private void btn_Usuario_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_Usuario());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_Fecha.Text=DateTime.Now.ToShortDateString();
            lbl_hora.Text=DateTime.Now.ToLongTimeString();
        }

        private void btn_CerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
