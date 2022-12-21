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
    public partial class Frm_Provincias : Form
    {
        public Frm_Provincias()
        {
            InitializeComponent();
        }
        #region "Mis Variables"

        int Estado_Guardar = 0;//Sin accion

        int Codigo_po=0;

        int Codigo_pa = 0;

        #endregion

        private void Frm_Provincias_Load(object sender, EventArgs e)
        {
            this.Listado_po("%");
            this.Listado_pa_po("%");
        }

        #region"Mis Metodos"
        private void Formato_po()
        {
            dgvPrincipal.Columns[0].Width = 100;
            dgvPrincipal.Columns[0].HeaderText = "CODIGO";
            dgvPrincipal.Columns[1].Width = 206;
            dgvPrincipal.Columns[1].HeaderText = "PROVINCIA";
            dgvPrincipal.Columns[2].Width = 206;
            dgvPrincipal.Columns[2].HeaderText = "PAIS";
            dgvPrincipal.Columns[3].Visible = false;


        }

        private void Listado_po(string texto)
        {
            try
            {
                dgvPrincipal.DataSource = N_Provincias.Listado_po(texto);
                this.Formato_po();

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
            if (string.IsNullOrEmpty(Convert.ToString(dgvPrincipal.CurrentRow.Cells["codigo_po"].Value)))
            {
                MessageBox.Show("El Listado esta Vacio","Aviso del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_pa =Convert.ToInt32( dgvPrincipal.CurrentRow.Cells["codigo_pa"].Value);
                txt_descripcion_marca.Text =Convert.ToString( dgvPrincipal.CurrentRow.Cells["descripcion_pa"].Value);

                this.Codigo_po = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells["codigo_po"].Value);
                txtMarcas.Text = Convert.ToString(dgvPrincipal.CurrentRow.Cells["descripcion_po"].Value);
            }
        }

        private void Formato_pa_po()
        {
            
            dgvPais.Columns[0].Width = 300;
            dgvPais.Columns[0].HeaderText = "PAIS";
            dgvPais.Columns[1].Visible = false;

        }

        private void Listado_pa_po(string texto)
        {
            try
            {
                dgvPais.DataSource = N_Provincias.Listado_pa_po(texto);
                this.Formato_pa_po();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void SeleccionaItem_pa_po()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgvPais.CurrentRow.Cells[0].Value)))
            {
                MessageBox.Show("El Listado esta Vacio", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_pa = Convert.ToInt32(dgvPais.CurrentRow.Cells[1].Value);
                txt_descripcion_marca.Text = Convert.ToString(dgvPais.CurrentRow.Cells[0].Value);
            }
        }
        #endregion

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtMarcas.Text==String.Empty || txt_descripcion_marca.Text == String.Empty)
            {
                MessageBox.Show("Ingrese los datos requeridos (*)","Aviso de Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
            else//Registra la Categoria
            {
                E_Provincias oPo = new E_Provincias();
                string Rpta = "";
                oPo.Codigo_po = this.Codigo_po;
                oPo.Descripcion_po = txtMarcas.Text;
                oPo.Codigo_pa=this.Codigo_pa;
               
                Rpta = N_Provincias.Guardar_po(Estado_Guardar,oPo);
                if (Rpta=="OK")
                {
                    Listado_po("%");
                    MessageBox.Show("La Categoria se Guardo de Forma Correcta!!!", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Estado_Guardar = 0;//Sin ninguna accion
                    this.Estado_Botones_Principales(true);
                    this.Estado_Botones_Procesos(false);
                    txtMarcas.Text = "";
                    txtMarcas.ReadOnly=true;
                    tabControlPrincipaL.SelectedIndex =0;
                    this.Codigo_po = 0;
                    
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
            this.Codigo_po=0;
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
            Codigo_po =0;
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
                    this.Codigo_po = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells[0].Value);
                    Rpta = N_Provincias.Eliminar_po(this.Codigo_po);

                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_po("%");
                        this.Codigo_po= 0;
                        MessageBox.Show("Registro Eliminado", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     
                    }

                }
               
               
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Listado_po(txtBuscar.Text.Trim());
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Reportes.Fmr_Rpt_Provincias oRp2 = new Reportes.Fmr_Rpt_Provincias();
            oRp2.textBox1.Text = txtBuscar.Text;
            oRp2.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_1_Click(object sender, EventArgs e)
        {
            this.Listado_pa_po(txtBuscar1.Text);
        }

        private void btn_lupa1_Click(object sender, EventArgs e)
        {
            pListado_Paises.Visible = true;

        }

        private void btnVolver1_Click(object sender, EventArgs e)
        {
            pListado_Paises.Visible = false;
        }

        private void dgvPais_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SeleccionaItem_pa_po();
            pListado_Paises.Visible=false;
            txt_descripcion_marca.Focus();
        }
    }
}
