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
    public partial class Frm_Ciudad : Form
    {
        public Frm_Ciudad()
        {
            InitializeComponent();
        }
        #region "Mis Variables"

        int Estado_Guardar = 0;//Sin accion

        int Codigo_ci=0;

        int Codigo_po = 0;

        #endregion

        private void Frm_Ciudad_Load(object sender, EventArgs e)
        {
            this.Listado_ci("%");
            this.Listado_po_ci("%");
        }

        #region"Mis Metodos"
        private void Formato_ci()
        {
            dgvPrincipal.Columns[0].Width = 100;
            dgvPrincipal.Columns[0].HeaderText = "CODIGO";
            dgvPrincipal.Columns[1].Width = 206;
            dgvPrincipal.Columns[1].HeaderText = "CIUDAD";
            dgvPrincipal.Columns[2].Width = 206;
            dgvPrincipal.Columns[2].HeaderText = "PROVINCIA";
            dgvPrincipal.Columns[3].Width = 206;
            dgvPrincipal.Columns[3].HeaderText = "PAIS";
            dgvPrincipal.Columns[4].Visible = false;


        }

        private void Listado_ci(string texto)
        {
            try
            {
                dgvPrincipal.DataSource = N_Ciudad.Listado_ci(texto);
                this.Formato_ci();

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
            if (string.IsNullOrEmpty(Convert.ToString(dgvPrincipal.CurrentRow.Cells["codigo_ci"].Value)))
            {
                MessageBox.Show("El Listado esta Vacio","Aviso del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_po =Convert.ToInt32( dgvPrincipal.CurrentRow.Cells["codigo_po"].Value);
                txt_Provincia.Text =Convert.ToString( dgvPrincipal.CurrentRow.Cells["descripcion_po"].Value);

                this.Codigo_ci = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells["codigo_ci"].Value);
                txt_Ciudad.Text = Convert.ToString(dgvPrincipal.CurrentRow.Cells["descripcion_ci"].Value);
            }
        }

        private void Formato_po_ci()
        {
            
            dgvProvincia.Columns[0].Width = 200;
            dgvProvincia.Columns[0].HeaderText = "PROVINCIA";
            dgvProvincia.Columns[1].Width = 200;
            dgvProvincia.Columns[1].HeaderText = "PAIS";
            dgvProvincia.Columns[2].Visible = false;

        }

        private void Listado_po_ci(string texto)
        {
            try
            {
                dgvProvincia.DataSource = N_Ciudad.Listado_po_ci(texto);
                this.Formato_po_ci();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void SeleccionaItem_po_ci()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgvProvincia.CurrentRow.Cells[0].Value)))
            {
                MessageBox.Show("El Listado esta Vacio", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_po = Convert.ToInt32(dgvProvincia.CurrentRow.Cells[2].Value);
                txt_Provincia.Text = Convert.ToString(dgvProvincia.CurrentRow.Cells[0].Value);
            }
        }
        #endregion

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txt_Ciudad.Text==String.Empty || txt_Provincia.Text == String.Empty)
            {
                MessageBox.Show("Ingrese los datos requeridos (*)","Aviso de Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
            else//Registra la Categoria
            {
                E_Ciudad oCi = new E_Ciudad();
                string Rpta = "";
                oCi.Codigo_ci = this.Codigo_ci;
                oCi.Desacripcion_ci = txt_Ciudad.Text;
                oCi.Codigo_po=this.Codigo_po;
               
                Rpta = N_Ciudad.Guardar_ci(Estado_Guardar,oCi);
                if (Rpta=="OK")
                {
                    Listado_ci("%");
                    MessageBox.Show("La Categoria se Guardo de Forma Correcta!!!", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Estado_Guardar = 0;//Sin ninguna accion
                    this.Estado_Botones_Principales(true);
                    this.Estado_Botones_Procesos(false);
                    txt_Ciudad.Text = "";
                    txt_Ciudad.ReadOnly=true;
                    tabControlPrincipaL.SelectedIndex =0;
                    this.Codigo_ci = 0;
                    
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
            txt_Ciudad.Text = "";
            txt_Ciudad.ReadOnly=false;
            tabControlPrincipaL.SelectedIndex = 1;
            txt_Ciudad.Focus();

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Estado_Guardar = 2;//Actualizar
            this.Estado_Botones_Principales(false);
            this.Estado_Botones_Procesos(true);
            this.SeleccionaItem();
            tabControlPrincipaL.SelectedIndex = 1;
            txt_Ciudad.ReadOnly = false;
            txt_Ciudad.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Estado_Guardar = 0;//sin Accion
            this.Codigo_ci=0;
            txt_Ciudad.Text = "";
            txt_Ciudad.ReadOnly = true;
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
            Codigo_ci =0;
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
                    this.Codigo_ci = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells[0].Value);
                    Rpta = N_Ciudad.Eliminar_ci(this.Codigo_ci);

                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_ci("%");
                        this.Codigo_ci= 0;
                        MessageBox.Show("Registro Eliminado", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     
                    }

                }
               
               
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Listado_ci(txtBuscar.Text.Trim());
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Reportes.Fmr_Rpt_Ciudad oRp2 = new Reportes.Fmr_Rpt_Ciudad();
            oRp2.textBox1.Text = txtBuscar.Text;
            oRp2.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_1_Click(object sender, EventArgs e)
        {
            this.Listado_po_ci(txtBuscarpo.Text);
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
            this.SeleccionaItem_po_ci();
            pListado_Paises.Visible=false;
            txt_Provincia.Focus();
        }
    }
}
