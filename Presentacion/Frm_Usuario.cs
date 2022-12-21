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
    public partial class Frm_Usuario : Form
    {
        public Frm_Usuario()
        {
            InitializeComponent();
        }
        #region "Mis Variables"

        int Estado_Guardar = 0;//Sin accion

        int Codigo_us=0;



        #endregion

        private void Frm_Usuario_Load(object sender, EventArgs e)
        {
            this.Listado_us("%");
        }

        #region"Mis Metodos"
        private void Formato_us()
        {
            dgvPrincipal.Columns[0].Width = 100;
            dgvPrincipal.Columns[0].HeaderText = "CÓDIGO";
            dgvPrincipal.Columns[1].Width = 100;
            dgvPrincipal.Columns[1].HeaderText = "LOGIN";
            dgvPrincipal.Columns[2].Width = 100;
            dgvPrincipal.Columns[2].HeaderText = "USUARIO";
            dgvPrincipal.Columns[3].Width = 100;
            dgvPrincipal.Columns[3].HeaderText = "ROL";
            dgvPrincipal.Columns[4].Visible=false;
        }

        private void Listado_us(string texto)
        {
            try
            {
                dgvPrincipal.DataSource =N_Usuarios.Listado_us(texto);
                this.Formato_us();

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
                    MessageBox.Show("El Listado esta Vacio", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.Codigo_us = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells[0].Value);
                    txt_Login.Text = Convert.ToString(dgvPrincipal.CurrentRow.Cells["login_us"].Value);
                    txt_Password.Text = "";
                    txt_Usuario.Text = Convert.ToString(dgvPrincipal.CurrentRow.Cells["nombre_us"].Value);
                    txt_Rol.Text = Convert.ToString(dgvPrincipal.CurrentRow.Cells["cargo_us"].Value);
                    cb_Admin.Checked = Convert.ToBoolean(dgvPrincipal.CurrentRow.Cells["admin"].Value);
                }
           
           
        }


        #endregion

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txt_Password.Text==String.Empty && Estado_Guardar==1)
            {
                    MessageBox.Show("Ingrese los datos requeridos (*)", "Aviso de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            else
            {

                if (txt_Login.Text == String.Empty || txt_Usuario.Text == String.Empty)
                {

                    MessageBox.Show("Ingrese los datos requeridos (*)", "Aviso de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else//Registra 
                {
                    E_Usuarios oUs = new E_Usuarios();
                    string Rpta = "";
                    oUs.Codigo_us = this.Codigo_us;
                    oUs.Login_us = txt_Login.Text.Trim();
                    oUs.Password_us = txt_Password.Text.Trim();
                    oUs.Nombre_us = txt_Usuario.Text.Trim();
                    oUs.Cargo_us = txt_Rol.Text.Trim();
                    oUs.Admin = cb_Admin.Checked;
                    Rpta = N_Usuarios.Guardar_us(Estado_Guardar, oUs);
                    if (Rpta == "OK")
                    {
                        Listado_us("%");
                        MessageBox.Show("EL Usuario se Guardo de Forma Correcta!!!", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Estado_Guardar = 0;//Sin ninguna accion
                        this.Estado_Botones_Principales(true);
                        this.Estado_Botones_Procesos(false);
                        txt_Password.Text = "";
                        txt_Login.Text = "";
                        txt_Usuario.Text = "";
                        txt_Rol.Text = "";
                        cb_Admin.Checked = false;

                        txt_Password.ReadOnly = true;
                        txt_Login.ReadOnly = true;
                        txt_Usuario.ReadOnly = true;
                        txt_Rol.ReadOnly = true;
                        cb_Admin.Enabled = false;
                        tabControlPrincipaL.SelectedIndex = 0;
                        this.Codigo_us = 0;

                    }
                    else
                    {
                        MessageBox.Show(Rpta, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Estado_Guardar = 1;//Nuevo Registro
            this.Estado_Botones_Principales(false);
            this.Estado_Botones_Procesos(true);
            txt_Password.Text = "";
            txt_Login.Text = "";
            txt_Usuario.Text = "";
            txt_Rol.Text = "";
            cb_Admin.Checked = false;

            txt_Password.ReadOnly = false;
            txt_Login.ReadOnly = false;
            txt_Usuario.ReadOnly = false;
            txt_Rol.ReadOnly = false;
            cb_Admin.Enabled = true;
            tabControlPrincipaL.SelectedIndex = 0;
            tabControlPrincipaL.SelectedIndex = 1;
            txt_Login.Focus();

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Estado_Guardar = 2;//Actualizar
            this.Estado_Botones_Principales(false);
            this.Estado_Botones_Procesos(true);
            this.SeleccionaItem();
            tabControlPrincipaL.SelectedIndex = 1;

            txt_Password.ReadOnly = false;
            txt_Usuario.ReadOnly = false;
            txt_Rol.ReadOnly=false;
            cb_Admin.Enabled=true;
            txt_Login.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Estado_Guardar = 0;//sin Accion
            this.Codigo_us =0;
            txt_Password.Text = "";
            txt_Login.Text = "";
            txt_Usuario.Text = "";
            txt_Rol.Text = "";
            cb_Admin.Checked = false;

            txt_Password.ReadOnly = true;
            txt_Login.ReadOnly = true;
            txt_Usuario.ReadOnly = true;
            txt_Rol.ReadOnly = true;
            cb_Admin.Enabled = false;

            tabControlPrincipaL.SelectedIndex = 0;
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
            Codigo_us =0;
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
                    this.Codigo_us = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells[0].Value);
                    Rpta = N_Usuarios.Eliminar_us(this.Codigo_us);

                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_us("%");
                        this.Codigo_us = 0;
                        MessageBox.Show("Registro Eliminado", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     
                    }

                }
               
               
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Listado_us(txtBuscar.Text.Trim());
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            //Reportes.Fmr_Rpt_UM oRp2 = new Reportes.Fmr_Rpt_UM();
            //oRp2.textBox1.Text = txtBuscar.Text;
            //oRp2.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
