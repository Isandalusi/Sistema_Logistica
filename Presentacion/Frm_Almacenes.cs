using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Frm_Almacenes : Form
    {
        public Frm_Almacenes()
        {
            InitializeComponent();
        }
        #region "Mis Variables"

        int Estado_Guardar = 0;//Sin accion

        int Codigo_al=0;



        #endregion

        private void Frm_Almacenes_Load(object sender, EventArgs e)
        {
            this.Listado_al("%");
        }

        #region"Mis Metodos"
        private void Formato_al()
        {
            dgvPrincipal.Columns[0].Width = 100;
            dgvPrincipal.Columns[0].HeaderText = "CODIGO";
            dgvPrincipal.Columns[1].Width = 300;
            dgvPrincipal.Columns[1].HeaderText = "ALMACEN";
        }

        private void Listado_al(string texto)
        {
            try
            {
                dgvPrincipal.DataSource = N_Almacenes.Listado_al(texto);
                this.Formato_al();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void Estado_Botones_Principales(bool lEstado)
        {
            this.btnNuevo.Enabled = lEstado;
            this.btnActualizar.Enabled = lEstado;
            this.btnEliminar.Enabled = lEstado;
            btnReporte.Enabled = lEstado;
            btnSalir.Enabled = lEstado;

        }
        private void Estado_Botones_Procesos(bool lEstado)
        {
            this.btnCancelar.Visible = lEstado;
            this.btnGuardar.Visible=lEstado;
            this.btnVolver.Visible=!lEstado;
        }

        private void SeleccionaItem()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgvPrincipal.CurrentRow.Cells[0].Value)))
            {
                MessageBox.Show("El Listado esta Vacio","Aviso del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_al =Convert.ToInt32( dgvPrincipal.CurrentRow.Cells[0].Value);
                txtAlmacenes.Text =Convert.ToString( dgvPrincipal.CurrentRow.Cells[1].Value);
            }
        }


        #endregion

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtAlmacenes.Text==String.Empty)
            {
                MessageBox.Show("Ingrese los datos requeridos (*)","Aviso de Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
            else//Registra la Categoria
            {
                E_Almacenes oAl = new E_Almacenes();
                string Rpta = "";
                oAl.Codigo_al=this.Codigo_al;
                oAl.Descripcion_al = txtAlmacenes.Text;
                Rpta = N_Almacenes.Guardar_al(Estado_Guardar,oAl);
                if (Rpta=="OK")
                {
                    Listado_al("%");
                    MessageBox.Show("La Categoria se Guardo de Forma Correcta!!!", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Estado_Guardar = 0;//Sin ninguna accion
                    this.Estado_Botones_Principales(true);
                    this.Estado_Botones_Procesos(false);
                    txtAlmacenes.Text = "";
                    txtAlmacenes.ReadOnly=true;
                    tabControlPrincipaL.SelectedIndex =0;
                    this.Codigo_al = 0;
                    
                }
                else
                {
                    MessageBox.Show(Rpta, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Estado_Guardar = 1;//Nuevo Registro
            this.Estado_Botones_Principales(false);
            this.Estado_Botones_Procesos(true);
            txtAlmacenes.Text = "";
            txtAlmacenes.ReadOnly=false;
            tabControlPrincipaL.SelectedIndex = 1;
            txtAlmacenes.Focus();

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Estado_Guardar = 2;//Actualizar
            this.Estado_Botones_Principales(false);
            this.Estado_Botones_Procesos(true);
            this.SeleccionaItem();
            tabControlPrincipaL.SelectedIndex = 1;
            txtAlmacenes.ReadOnly = false;
            txtAlmacenes.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Estado_Guardar = 0;//sin Accion
            this.Codigo_al =0;
            txtAlmacenes.Text = "";
            txtAlmacenes.ReadOnly = true;
            this.Estado_Botones_Principales(true);
            this.Estado_Botones_Procesos(false);
            tabControlPrincipaL.SelectedIndex = 0;

        }

        private void dgvPrincipal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SeleccionaItem();
            this.Estado_Botones_Procesos(false);
            tabControlPrincipaL.SelectedIndex = 1;

        }

        private void btnRetornar_Click(object sender, EventArgs e)
        {
            this.Estado_Botones_Procesos(false);
            tabControlPrincipaL.SelectedIndex = 0;
            Codigo_al =0;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgvPrincipal.CurrentRow.Cells[0].Value)))
            {
                MessageBox.Show("El Listado esta Vacio", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult Opcion;
               Opcion=MessageBox.Show("Estas Seguro de eliminar el registro Seleccionado??","Aviso Del Sistema",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                if (Opcion==DialogResult.Yes)
                {
                    string Rpta = "";
                    this.Codigo_al = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells[0].Value);
                    Rpta = N_Almacenes.Eliminar_al(this.Codigo_al);

                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_al("%");
                        this.Codigo_al = 0;
                        MessageBox.Show("Registro Eliminado", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     
                    }

                }
               
               
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Listado_al(txtBuscar.Text.Trim());
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Reportes.Fmr_Rpt_Almacen oRp2 = new Reportes.Fmr_Rpt_Almacen();
            oRp2.textBox1.Text=txtBuscar.Text;
            oRp2.ShowDialog(); 
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
