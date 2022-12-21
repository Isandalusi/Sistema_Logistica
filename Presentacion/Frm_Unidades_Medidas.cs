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
    public partial class Frm_Unidades_Medidas : Form
    {
        public Frm_Unidades_Medidas()
        {
            InitializeComponent();
        }
        #region "Mis Variables"

        int Estado_Guardar = 0;//Sin accion

        int Codigo_um=0;



        #endregion

        private void Frm_Unidades_Medidas_Load(object sender, EventArgs e)
        {
            this.Listado_um("%");
        }

        #region"Mis Metodos"
        private void Formato_um()
        {
            dgvPrincipal.Columns[0].Width = 100;
            dgvPrincipal.Columns[0].HeaderText = "CODIGO";
            dgvPrincipal.Columns[1].Width = 100;
            dgvPrincipal.Columns[1].HeaderText = "ABREVIATURA";
            dgvPrincipal.Columns[2].Width = 300;
            dgvPrincipal.Columns[2].HeaderText = "UNIDAD DE MEDIDA";
        }

        private void Listado_um(string texto)
        {
            try
            {
                dgvPrincipal.DataSource = N_Unidades_Medidas.Listado_um(texto);
                this.Formato_um();

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
                this.Codigo_um =Convert.ToInt32( dgvPrincipal.CurrentRow.Cells[0].Value);
                txtUM.Text =Convert.ToString( dgvPrincipal.CurrentRow.Cells[1].Value);
                txtAbreviatura.Text = Convert.ToString( dgvPrincipal.CurrentRow.Cells[2].Value);
            }
        }


        #endregion

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtAbreviatura.Text==String.Empty|| txtUM.Text==String.Empty)
            {
                MessageBox.Show("Ingrese los datos requeridos (*)","Aviso de Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
            else//Registra la Categoria
            {
                E_Unidades_Medidas oUm = new E_Unidades_Medidas();
                string Rpta = "";
                oUm.Codigo_um=this.Codigo_um;
                oUm.Abreviatura_um=txtAbreviatura.Text;
                oUm.Descripcion_um = txtUM.Text;
                Rpta = N_Unidades_Medidas.Guardar_um(Estado_Guardar,oUm);
                if (Rpta=="OK")
                {
                    Listado_um("%");
                    MessageBox.Show("La Medida se Guardo de Forma Correcta!!!", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Estado_Guardar = 0;//Sin ninguna accion
                    this.Estado_Botones_Principales(true);
                    this.Estado_Botones_Procesos(false);
                    txtUM.Text = "";
                    txtAbreviatura.Text = "";
                    txtUM.ReadOnly=true;
                    txtAbreviatura.ReadOnly = true;
                    tabControlPrincipaL.SelectedIndex =0;
                    this.Codigo_um = 0;
                    
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
            txtUM.Text = "";
            txtAbreviatura.Text = "";
            txtUM.ReadOnly=false;
            txtAbreviatura.ReadOnly = false;
            tabControlPrincipaL.SelectedIndex = 1;
            txtAbreviatura.Focus();

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Estado_Guardar = 2;//Actualizar
            this.Estado_Botones_Principales(false);
            this.Estado_Botones_Procesos(true);
            this.SeleccionaItem();
            tabControlPrincipaL.SelectedIndex = 1;
            txtUM.ReadOnly = false;
            txtAbreviatura.ReadOnly = false;
            txtAbreviatura.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Estado_Guardar = 0;//sin Accion
            this.Codigo_um =0;
            txtUM.Text = "";
            txtUM.Text = "";
            txtUM.ReadOnly = true;
            txtAbreviatura.ReadOnly = true;
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
            Codigo_um =0;
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
                    this.Codigo_um = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells[0].Value);
                    Rpta = N_Unidades_Medidas.Eliminar_um(this.Codigo_um);

                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_um("%");
                        this.Codigo_um = 0;
                        MessageBox.Show("Registro Eliminado", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     
                    }

                }
               
               
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Listado_um(txtBuscar.Text.Trim());
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Reportes.Fmr_Rpt_UM oRp2 = new Reportes.Fmr_Rpt_UM();
            oRp2.textBox1.Text = txtBuscar.Text;
            oRp2.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
