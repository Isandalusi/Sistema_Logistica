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
    public partial class Frm_Rubros : Form
    {
        public Frm_Rubros()
        {
            InitializeComponent();
        }
        #region "Mis Variables"

        int Estado_Guardar = 0;//Sin accion

        int Codigo_ru=0;



        #endregion

        private void Frm_Rubros_Load(object sender, EventArgs e)
        {
            this.Listado_ru("%");
        }

        #region"Mis Metodos"
        private void Formato_ru()
        {
            dgvPrincipal.Columns[0].Width = 100;
            dgvPrincipal.Columns[0].HeaderText = "CODIGO";
            dgvPrincipal.Columns[1].Width = 300;
            dgvPrincipal.Columns[1].HeaderText = "RUBRO";
        }

        private void Listado_ru(string texto)
        {
            try
            {
                dgvPrincipal.DataSource = N_Rubro.Listado_ru(texto);
                this.Formato_ru();

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
                this.Codigo_ru =Convert.ToInt32( dgvPrincipal.CurrentRow.Cells[0].Value);
                txtMarcas.Text =Convert.ToString( dgvPrincipal.CurrentRow.Cells[1].Value);
            }
        }


        #endregion

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtMarcas.Text==String.Empty)
            {
                MessageBox.Show("Ingrese los datos requeridos (*)","Aviso de Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
            else//Registra la Categoria
            {
                E_Rubros oRu = new E_Rubros();
                string Rpta = "";
                oRu.Codigo_ru=this.Codigo_ru;
                oRu.Descripcion_ru = txtMarcas.Text;
                Rpta = N_Rubro.Guardar_ru(Estado_Guardar,oRu);
                if (Rpta=="OK")
                {
                    Listado_ru("%");
                    MessageBox.Show("La Categoria se Guardo de Forma Correcta!!!", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Estado_Guardar = 0;//Sin ninguna accion
                    this.Estado_Botones_Principales(true);
                    this.Estado_Botones_Procesos(false);
                    txtMarcas.Text = "";
                    txtMarcas.ReadOnly=true;
                    tabControlPrincipaL.SelectedIndex =0;
                    this.Codigo_ru = 0;
                    
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
            txtMarcas.Text = "";
            txtMarcas.ReadOnly=false;
            tabControlPrincipaL.SelectedIndex = 1;
            txtMarcas.Focus();

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Estado_Guardar = 2;//Actualizar
            this.Estado_Botones_Principales(false);
            this.Estado_Botones_Procesos(true);
            this.SeleccionaItem();
            tabControlPrincipaL.SelectedIndex = 1;
            txtMarcas.ReadOnly = false;
            txtMarcas.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Estado_Guardar = 0;//sin Accion
            this.Codigo_ru =0;
            txtMarcas.Text = "";
            txtMarcas.ReadOnly = true;
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
            Codigo_ru =0;
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
                    this.Codigo_ru = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells[0].Value);
                    Rpta = N_Rubro.Eliminar_ru(this.Codigo_ru);

                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_ru("%");
                        this.Codigo_ru = 0;
                        MessageBox.Show("Registro Eliminado", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     
                    }

                }
               
               
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Listado_ru(txtBuscar.Text.Trim());
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Reportes.Fmr_Rpt_Rubro oRp2 = new Reportes.Fmr_Rpt_Rubro();
            oRp2.textBox1.Text = txtBuscar.Text;
            oRp2.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
