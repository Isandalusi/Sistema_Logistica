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
using System.Windows.Forms.VisualStyles;

namespace Presentacion
{
    public partial class Frm_Clientes : Form
    {
        public Frm_Clientes()
        {
            InitializeComponent();
        }
        #region "Mis Variables"

        int Estado_Guardar = 0;//Sin accion

        int Codigo_cl = 0;
        int Codigo_tdpc = 0;
        int Codigo_sx = 0;
        int Codigo_ru = 0;
        int Codigo_ci = 0;

        #endregion


        #region"Mis Metodos"
        private void Formato_cl()
        {
            dgvPrincipal.Columns[0].Width = 98;
            dgvPrincipal.Columns[0].HeaderText = "CODIGO";
            dgvPrincipal.Columns[1].Width = 150;
            dgvPrincipal.Columns[1].HeaderText = "TIPO DOCUMENTO";
            dgvPrincipal.Columns[2].Width = 150;
            dgvPrincipal.Columns[2].HeaderText = "N° DOCUMENTO";
            dgvPrincipal.Columns[3].Width = 200;
            dgvPrincipal.Columns[3].HeaderText = "RAZON SOCIAL";
            dgvPrincipal.Columns[4].Width = 200;
            dgvPrincipal.Columns[4].HeaderText = "NOMBRE";
            dgvPrincipal.Columns[5].Width = 200;
            dgvPrincipal.Columns[5].HeaderText = "APELLIDO";
            dgvPrincipal.Columns[6].Width = 150;
            dgvPrincipal.Columns[6].HeaderText = "RUBRO";
            dgvPrincipal.Columns[7].Visible = false;
            dgvPrincipal.Columns[8].Visible = false;
            dgvPrincipal.Columns[9].Visible = false;
            dgvPrincipal.Columns[10].Visible = false;
            dgvPrincipal.Columns[11].Visible = false;
            dgvPrincipal.Columns[12].Visible = false;
            dgvPrincipal.Columns[13].Visible = false;
            dgvPrincipal.Columns[14].Visible = false;
            dgvPrincipal.Columns[15].Visible = false;
            dgvPrincipal.Columns[16].Visible = false;
            dgvPrincipal.Columns[17].Visible = false;
            dgvPrincipal.Columns[18].Visible = false;
            dgvPrincipal.Columns[19].Visible = false;

        }

        private void Listado_cl(string texto)
        {
            try
            {
                dgvPrincipal.DataSource =N_Clientes.Listado_cl(texto);
                this.Formato_cl();

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
            this.btnGuardar.Visible = lEstado;
            this.btnVolver.Visible = !lEstado;
        }

        private void SeleccionaItem()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgvPrincipal.CurrentRow.Cells[0].Value)))
            {
                MessageBox.Show("El Listado esta Vacio", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string Ciudad = "";
                this.Codigo_cl = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells["codigo_cl"].Value);
                this.Codigo_tdpc = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells["codigo_tdpc"].Value);
                txt_descripcion_tipo_documento.Text = Convert.ToString(dgvPrincipal.CurrentRow.Cells["descripcion_tdpc"].Value);
                txt_NroDocumento.Text = Convert.ToString(dgvPrincipal.CurrentRow.Cells["nrodocumento_cl"].Value);
                txt_Razon_social.Text = Convert.ToString(dgvPrincipal.CurrentRow.Cells["razon_social_cl"].Value);
                txt_Nombre.Text = Convert.ToString(dgvPrincipal.CurrentRow.Cells["nombres"].Value);
                txt_Apellido.Text = Convert.ToString(dgvPrincipal.CurrentRow.Cells["apellidos"].Value);
                this.Codigo_ru = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells["codigo_ru"].Value);
                txt_descripcion_rubro.Text = Convert.ToString(dgvPrincipal.CurrentRow.Cells["descripcion_ru"].Value);
                txt_Email.Text = Convert.ToString(dgvPrincipal.CurrentRow.Cells["email_cl"].Value);
                txt_Telefono.Text = Convert.ToString(dgvPrincipal.CurrentRow.Cells["telefono_cl"].Value);
                txtCelular.Text = Convert.ToString(dgvPrincipal.CurrentRow.Cells["celular_cl"].Value);
                this.Codigo_sx = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells["codigo_sx"].Value);
                txt_Sexo.Text = Convert.ToString(dgvPrincipal.CurrentRow.Cells["descripcion_sx"].Value);
                txt_direccion.Text = Convert.ToString(dgvPrincipal.CurrentRow.Cells["direccion_cl"].Value);
                this.Codigo_ci = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells["codigo_ci"].Value);
                Ciudad = Convert.ToString(dgvPrincipal.CurrentRow.Cells["descripcion_ci"].Value).Trim() + "/" +
                         Convert.ToString(dgvPrincipal.CurrentRow.Cells["descripcion_po"].Value).Trim() + "/" +
                         Convert.ToString(dgvPrincipal.CurrentRow.Cells["descripcion_pa"].Value).Trim();
                txt_CPP.Text = Ciudad;
                txt_Observaciones.Text = Convert.ToString(dgvPrincipal.CurrentRow.Cells["observacion_cl"].Value);



            }
        }

        private void Formato_tdpv()
        {
            dgv_TipoDocumento.Columns[0].Width = 250;
            dgv_TipoDocumento.Columns[0].HeaderText = "TIPO DOCUMENTO";
            dgv_TipoDocumento.Columns[1].Visible = false;
        }

        private void Listado_tdpc()
        {
            try
            {
                dgv_TipoDocumento.DataSource = N_Clientes.Listado_td_cl();
                this.Formato_tdpv();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void SeleccionaItem_tdpc()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgv_TipoDocumento.CurrentRow.Cells[0].Value)))
            {
                MessageBox.Show("El Listado esta Vacio", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_tdpc = Convert.ToInt32(dgv_TipoDocumento.CurrentRow.Cells[1].Value);
                txt_descripcion_tipo_documento.Text = Convert.ToString(dgv_TipoDocumento.CurrentRow.Cells[0].Value);
            }
        }

        private void Formato_sx()
        {
            dgvSx.Columns[0].Width = 250;
            dgvSx.Columns[0].HeaderText = "SEXO";
            dgvSx.Columns[1].Visible = false;
        }

        private void Listado_sx()
        {
            try
            {
                dgvSx.DataSource = N_Clientes.Listado_sx_cl();
                this.Formato_sx();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void SeleccionaItem_sx()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgvSx.CurrentRow.Cells[0].Value)))
            {
                MessageBox.Show("El Listado esta Vacio", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_sx = Convert.ToInt32(dgvSx.CurrentRow.Cells[1].Value);
                txt_Sexo.Text = Convert.ToString(dgvSx.CurrentRow.Cells[0].Value);
            }
        }

        private void Formato_ru()
        {
            dgvRubro.Columns[0].Width = 200;
            dgvRubro.Columns[0].HeaderText = "RUBROS";
            dgvRubro.Columns[1].Visible = false;
        }

        private void Listado_ru(string Texto)
        {
            try
            {
                dgvRubro.DataSource = N_Clientes.Listado_ru_cl(Texto);
                this.Formato_ru();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void SeleccionaItem_ru()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgvRubro.CurrentRow.Cells[0].Value)))
            {
                MessageBox.Show("El Listado esta Vacio", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_ru = Convert.ToInt32(dgvRubro.CurrentRow.Cells[1].Value);
                txt_descripcion_rubro.Text = Convert.ToString(dgvRubro.CurrentRow.Cells[0].Value);
            }
        }

        private void Formato_ci()
        {
            dgv_Ciudades.Columns[0].Width = 180;
            dgv_Ciudades.Columns[0].HeaderText = "CIUDAD";
            dgv_Ciudades.Columns[1].Width = 180;
            dgv_Ciudades.Columns[1].HeaderText = "PROVINCIA";
            dgv_Ciudades.Columns[2].Width = 150;
            dgv_Ciudades.Columns[2].HeaderText = "PAIS";
            dgv_Ciudades.Columns[3].Visible = false;
        }

        private void Listado_ci(string Texto)
        {
            try
            {
                dgv_Ciudades.DataSource = N_Clientes.Listado_ci_cl(Texto);
                this.Formato_ci();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void SeleccionaItem_ci()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgv_Ciudades.CurrentRow.Cells[0].Value)))
            {
                MessageBox.Show("El Listado esta Vacio", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_ci = Convert.ToInt32(dgv_Ciudades.CurrentRow.Cells["codigo_ci"].Value);
                txt_CPP.Text = Convert.ToString(dgv_Ciudades.CurrentRow.Cells["descripcion_ci"].Value) +" / "+
                               Convert.ToString(dgv_Ciudades.CurrentRow.Cells["descripcion_po"].Value)  +" / "+
                               Convert.ToString(dgv_Ciudades.CurrentRow.Cells["descripcion_pa"].Value);
            }
        }


        private void Estado_texto(bool lestado)
        {
            txt_NroDocumento.ReadOnly=!lestado;
            txt_Razon_social.ReadOnly = !lestado;
            txt_Nombre.ReadOnly=!lestado;
            txt_Apellido.ReadOnly=!lestado;
            txt_Email.ReadOnly=!lestado;
            txt_Telefono.ReadOnly=!lestado;
            txtCelular.ReadOnly=!lestado;
            txt_direccion.ReadOnly=!lestado;
            txt_Observaciones.ReadOnly=!lestado;
        }

        private void Limpia_texto()
        {
            txt_NroDocumento.Text = "";
            txt_Razon_social.Text = "";
            txt_Nombre.Text ="";
            txt_Apellido.Text = "";
            txt_Email.Text = "";
            txt_Telefono.Text = "";
            txtCelular.Text = "";
            txt_direccion.Text = "";
            txt_Observaciones.Text = "";
        }

        #endregion

        private void Frm_Clientes_Load(object sender, EventArgs e)
        {
            this.Listado_cl("%");
            this.Listado_tdpc();
            this.Listado_sx();
            this.Listado_ru("%");
            this.Listado_ci("%");

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txt_NroDocumento.Text == String.Empty || txt_descripcion_tipo_documento.Text == String.Empty || txt_descripcion_rubro.Text == String.Empty || txt_Sexo.Text == String.Empty || txt_CPP.Text == String.Empty || txt_direccion.Text == String.Empty)
            {
                MessageBox.Show("Ingrese los datos requeridos (*)", "Aviso de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else//Registra el proveedor
            {

                string Rpta = "";
                E_Clientes oCl = new E_Clientes();
                oCl.Codigo_cl = this.Codigo_cl;
                oCl.Codigo_tdpc = this.Codigo_tdpc;
                oCl.Nro_Documento_cl = txt_NroDocumento.Text.Trim();
                oCl.RazonSocial_cl = txt_Razon_social.Text.Trim();
                oCl.Nombre = txt_Nombre.Text.Trim();
                oCl.Apellido = txt_Apellido.Text.Trim();
                oCl.Codigo_sx = this.Codigo_sx;
                oCl.Codigo_ru = this.Codigo_ru;
                oCl.Email_cl = txt_Email.Text.Trim();
                oCl.Telefono_cl = txt_Telefono.Text.Trim();
                oCl.Celular_cl=txtCelular.Text.Trim();
                oCl.Direccion_cl=txt_direccion.Text.Trim();
                oCl.Codigo_ci = this.Codigo_ci;
                oCl.Observaciones_cl=txt_Observaciones.Text.Trim();
                Rpta = N_Clientes.Guardar_cl(Estado_Guardar,oCl);
                if (Rpta == "OK")
                {
                    Listado_cl("%");
                    MessageBox.Show("El Cliente se Guardo de Forma Correcta!!!", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Estado_Guardar = 0;//Sin ninguna accion
                    this.Estado_Botones_Principales(true);
                    this.Estado_Botones_Procesos(false);
                    this.Estado_texto(false);
                    tabControlPrincipaL.SelectedIndex = 0;
                    this.Codigo_cl = 0;
                    
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
            this.Limpia_texto();
            this.Estado_texto(true);
          
            tabControlPrincipaL.SelectedIndex = 1;
            txt_NroDocumento.Focus();
           
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Estado_Guardar = 2;//Actualiza Registro
            this.SeleccionaItem();
            this.Estado_Botones_Principales(false);
            this.Estado_Botones_Procesos(true);
            this.Estado_texto(true);
            tabControlPrincipaL.SelectedIndex = 1;
            txt_NroDocumento.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            
            Estado_Guardar = 0;//sin Accion

            this.Codigo_cl = 0;
            this.Codigo_tdpc = 0;
            this.Codigo_ru = 0;
            this.Codigo_ci = 0;
            this.Codigo_sx = 0;
            this.Estado_texto(false);
            this.Limpia_texto();
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
                    this.Codigo_cl = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells[0].Value);
                    Rpta = N_Clientes.Eliminar_cl(this.Codigo_cl);

                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_cl("%");
                        this.Codigo_cl = 0;
                        MessageBox.Show("Registro Eliminado", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     
                    }

                }
               
               
            }
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Listado_cl(txtBuscar.Text.Trim());
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
           Reportes.Frm_Rpt_Clientes  oRp2 = new Reportes.Frm_Rpt_Clientes();
           oRp2.textBox1.Text=txtBuscar.Text;
           oRp2.ShowDialog(); 
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_lupa1_Click(object sender, EventArgs e)
        {
            this.p_listado_TD.Location = btn_lupa2.Location;
            this.p_listado_TD.Visible = true;
        }

       

        private void btn_lupa2_Click(object sender, EventArgs e)
        {
            this.pListado_Sexo.Location = btn_lupa1.Location;
            this.pListado_Sexo.Visible = true;
        }

       
        private void btnbuscar2_Click(object sender, EventArgs e)
        {
           // this.Listado_um(txtbuscar2.Text);
        }

        private void VotonVolver1_Click(object sender, EventArgs e)
        {
            pListado_Sexo.Visible = false;
        }

        private void btnvolver2_Click(object sender, EventArgs e)
        {
            p_listado_TD.Visible=false;
        }

        private void dgv_medidas_DoubleClick(object sender, EventArgs e)
        {
            // this.SeleccionaItem_um_pr();
            p_listado_TD.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Listado_ru(txtBuscarRubro.Text);
           
        }

        private void btn_lupa_3_Click(object sender, EventArgs e)
        {

            this.pRubro.Location = btn_lupa1.Location;
            this.pRubro.Visible = true;

        }

       
        private void btnvolver3_Click(object sender, EventArgs e)
        {
            pRubro.Visible = false;
        }

        private void dgvPrincipal_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionaItem();
            this.Estado_Botones_Procesos(false);
            tabControlPrincipaL.SelectedIndex = 1;
            
        }

        private void dgvPrincipal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txt_descripcion_marca_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgv_TipoDocumento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SeleccionaItem_tdpc();
            p_listado_TD.Visible = false;
            txt_NroDocumento.Focus();
        }

        private void dgvSx_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SeleccionaItem_sx();
            pListado_Sexo.Visible = false;
            txt_Sexo.Focus();
        }

        private void dgvRubro_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SeleccionaItem_ru();
            pRubro.Visible = false;
            txt_Email.Focus();
        }

        private void btn_lupa_5_Click(object sender, EventArgs e)
        {
            this.pCiudades.Location = btn_lupa1.Location;
            this.pCiudades.Visible = true;
        }

        private void btn_volver_ci_Click(object sender, EventArgs e)
        {
            pCiudades.Visible=false;
        }

        private void bnt_buscar_ci_Click(object sender, EventArgs e)
        {
            this.Listado_ci(txt_Buscarci.Text);
        }

        private void dgv_Ciudades_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            this.SeleccionaItem_ci();
            pCiudades.Visible = false;
            txt_Observaciones.Focus();
        }
    }
}
